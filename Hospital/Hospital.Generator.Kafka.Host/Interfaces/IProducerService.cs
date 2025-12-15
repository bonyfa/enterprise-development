using Hospital.Application.Contracts.Appointments;

namespace Hospital.Generator.Kafka.Host.Interfaces;

/// <summary>
/// Abstraction for producing batches of appointment create or update contracts to a message broker
/// </summary>
public interface IProducerService
{
    /// <summary>
    /// Sends a batch of appointment create or update contracts
    /// </summary>
    /// <param name="batch">Batch of appointment create or update contracts to send</param>
    /// <returns>Task representing asynchronous send operation</returns>
    public Task SendAsync(IList<AppointmentCreateUpdateDto> batch);
}