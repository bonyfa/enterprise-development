using Confluent.Kafka;
using System.Text.Json;

namespace Hospital.Infrastructure.Kafka.Deserializers;

/// <summary>
/// Kafka deserializer for message key represented as Guid encoded in JSON
/// </summary>
public class HospitalKeyDeserializer : IDeserializer<Guid>
{
    /// <summary>
    /// Deserializes Kafka message key payload into Guid value
    /// </summary>
    /// <param name="data">Raw message key bytes</param>
    /// <param name="isNull">Indicates that the key is null</param>
    /// <param name="context">Serialization context</param>
    /// <returns>Deserialized Guid key</returns>
    public Guid Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    {
        if (isNull)
            throw new ArgumentNullException(nameof(data), "Kafka message key is null");

        return JsonSerializer.Deserialize<Guid>(data);
    }
}