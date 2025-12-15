using Confluent.Kafka;
using Hospital.Application.Contracts.Appointments;
using Hospital.Generator.Kafka.Host.Interfaces;

namespace Hospital.Generator.Kafka.Host;

/// <summary>
/// Kafka producer service that publishes batches of appointment create or update contracts to a configured topic
/// </summary>
/// <param name="configuration">Application configuration used to resolve Kafka topic name</param>
/// <param name="producer">Kafka producer used to send messages</param>
/// <param name="logger">Logger instance</param>
public sealed class HospitalKafkaProducer(
    IConfiguration configuration,
    IProducer<Guid, IList<AppointmentCreateUpdateDto>> producer,
    ILogger<HospitalKafkaProducer> logger) : IProducerService
{
    private readonly string _topicName =
        configuration.GetSection("Kafka")["TopicName"] ?? throw new KeyNotFoundException("TopicName section of Kafka is missing");

    /// <summary>
    /// Sends a batch of appointment contracts to Kafka topic using a randomly generated message key
    /// </summary>
    /// <param name="batch">Batch of appointment create or update contracts</param>
    public async Task SendAsync(IList<AppointmentCreateUpdateDto> batch)
    {
        try
        {
            logger.LogInformation("Sending a batch of {count} contracts to {topic}", batch.Count, _topicName);

            var message = new Message<Guid, IList<AppointmentCreateUpdateDto>>
            {
                Key = Guid.NewGuid(),
                Value = batch
            };

            await producer.ProduceAsync(_topicName, message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception occured during sending a batch of {count} contracts to {topic}", batch.Count, _topicName);
        }
    }
}