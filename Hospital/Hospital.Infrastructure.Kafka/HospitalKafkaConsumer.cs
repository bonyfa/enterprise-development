using Confluent.Kafka;
using Hospital.Application.Contracts.Appointments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Hospital.Infrastructure.Kafka;

/// <summary>
/// Kafka background consumer that subscribes to configured topic and creates appointments from received contracts
/// </summary>
/// <param name="consumer">Kafka consumer instance</param>
/// <param name="scopeFactory">Service scope factory used to resolve scoped services</param>
/// <param name="configuration">Application configuration used to read Kafka settings</param>
/// <param name="logger">Logger instance</param>
public class HospitalKafkaConsumer(
    IConsumer<Guid, IList<AppointmentCreateUpdateDto>> consumer, 
    IServiceScopeFactory scopeFactory, 
    IConfiguration configuration, 
    ILogger<HospitalKafkaConsumer> logger) : BackgroundService
{
    private readonly string _topicName = configuration.GetSection("Kafka")["TopicName"] ?? throw new KeyNotFoundException("TopicName section of Kafka is missing");

    /// <summary>
    /// Starts consumer execution loop
    /// </summary>
    /// <param name="stoppingToken">Cancellation token</param>
    /// <returns>Task representing background execution</returns>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        await Task.Yield();
        await Consume(stoppingToken);
    }

    private async Task Consume(CancellationToken stoppingToken)
    {
        consumer.Subscribe(_topicName);
        logger.LogInformation("Consumer successfully subscribed to topic {topic}", _topicName);

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                ConsumeResult<Guid, IList<AppointmentCreateUpdateDto>>? consumeResult;

                try
                {
                    consumeResult = consumer.Consume(stoppingToken);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }

                if (consumeResult?.Message?.Value is null || consumeResult.Message.Value.Count == 0)
                    continue;

                logger.LogInformation("Consumed message {key} from topic {topic} via consumer {consumer}", consumeResult.Message.Key, _topicName, consumer.Name);

                using var scope = scopeFactory.CreateScope();
                var appointmentService = scope.ServiceProvider.GetRequiredService<IAppointmentService>();

                try
                {
                    foreach (var contract in consumeResult.Message.Value)
                    {
                        await appointmentService.Create(contract);
                    }

                    consumer.Commit(consumeResult);
                    logger.LogInformation("Successfully processed and committed message {key} from topic {topic} via consumer {consumer}", consumeResult.Message.Key, _topicName, consumer.Name);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Failed to process message {key} from topic {topic} via consumer {consumer}", consumeResult.Message.Key, _topicName, consumer.Name);
                }
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception occured during receiving contracts from {topic}", _topicName);
        }
        finally
        {
            consumer.Close();
        }
    }
}