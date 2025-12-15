using Confluent.Kafka;
using Hospital.Application.Contracts.Appointments;
using System.Text.Json;

namespace Hospital.Generator.Kafka.Host.Serializers;

/// <summary>
/// Kafka serializer that converts a list of appointment create or update contracts into UTF8 JSON bytes
/// </summary>
public sealed class HospitalValueSerializer : ISerializer<IList<AppointmentCreateUpdateDto>>
{
    /// <summary>
    /// Serializes contract batch into JSON byte array representation
    /// </summary>
    /// <param name="data">Batch of appointment contracts to serialize</param>
    /// <param name="context">Serialization context provided by Kafka client</param>
    /// <returns>UTF8 JSON byte array</returns>
    public byte[] Serialize(IList<AppointmentCreateUpdateDto> data, SerializationContext context) =>
        JsonSerializer.SerializeToUtf8Bytes(data);
}