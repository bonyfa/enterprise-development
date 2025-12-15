using Confluent.Kafka;
using Hospital.Application.Contracts.Appointments;
using System.Text.Json;

namespace Hospital.Infrastructure.Kafka.Deserializers;

/// <summary>
/// Kafka deserializer for message value represented as JSON array of AppointmentCreateUpdateDto contracts
/// </summary>
public sealed class HospitalValueDeserializer : IDeserializer<IList<AppointmentCreateUpdateDto>>
{
    /// <summary>
    /// Deserializes Kafka message value payload into list of AppointmentCreateUpdateDto contracts
    /// </summary>
    /// <param name="data">Raw message value bytes</param>
    /// <param name="isNull">Indicates that the value is null</param>
    /// <param name="context">Serialization context</param>
    /// <returns>Deserialized list of contracts or empty list when value is null</returns>
    public IList<AppointmentCreateUpdateDto> Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    {
        if (isNull)
            return [];

        return JsonSerializer.Deserialize<IList<AppointmentCreateUpdateDto>>(data) ?? [];
    }
}