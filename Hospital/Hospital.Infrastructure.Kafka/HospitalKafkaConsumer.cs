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
public sealed class HospitalKafkaConsumer(
    IConsumer<Guid, IList<AppointmentCreateUpdateDto>> consumer,
    IServiceScopeFactory scopeFactory,
    IConfiguration configuration,
    ILogger<HospitalKafkaConsumer> logger) : BackgroundService
{
    private readonly string _topicName =
        configuration.GetSection("Kafka")["TopicName"] ?? throw new KeyNotFoundException("TopicName section of Kafka is missing");

    /// <summary>
    /// Starts consumer execution loop
    /// </summary>
    /// <param name="stoppingToken">Cancellation token</param>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Task.Yield();

        try
        {
            consumer.Subscribe(_topicName);
            logger.LogInformation("Consumer successfully subscribed to topic {topic}", _topicName);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to subscribe consumer {consumer} to topic {topic}", consumer.Name, _topicName);
            return;
        }

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = consumer.Consume(stoppingToken);

                    if (consumeResult?.Message?.Value is null || consumeResult.Message.Value.Count == 0)
                        continue;

                    logger.LogInformation(
                        "Consumed message {key} from topic {topic} via consumer {consumer}",
                        consumeResult.Message.Key, _topicName, consumer.Name);

                    using var scope = scopeFactory.CreateScope();
                    var appointmentService = scope.ServiceProvider.GetRequiredService<IAppointmentService>();

                    foreach (var contract in consumeResult.Message.Value)
                    {
                        try
                        {
                            await appointmentService.Create(contract);
                        }
                        catch (KeyNotFoundException ex)
                        {
                            logger.LogWarning(ex, "Skipping invalid appointment contract PatientId={patientId} DoctorId={doctorId}", contract.PatientId, contract.DoctorId);
                        }
                    }

                    consumer.Commit(consumeResult);

                    logger.LogInformation(
                        "Successfully processed and committed message {key} from topic {topic} via consumer {consumer}",
                        consumeResult.Message.Key, _topicName, consumer.Name);
                }
                catch (ConsumeException ex) when (ex.Error.Code == ErrorCode.UnknownTopicOrPart)
                {
                    logger.LogWarning("Topic {topic} is not available yet, waiting...", _topicName);
                    await Task.Delay(2000, stoppingToken);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Failed to consume or process message from topic {topic}", _topicName);
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }
        finally
        {
            try
            {
                consumer.Close();
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "Error during consumer close");
            }
        }
    }
}