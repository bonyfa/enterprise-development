using Confluent.Kafka;
using System.Text.Json;

namespace Hospital.Generator.Kafka.Host.Serializers;

/// <summary>
/// Kafka serializer that converts a GUID key into UTF8 JSON bytes
/// </summary>
public sealed class HospitalKeySerializer : ISerializer<Guid>
{
    /// <summary>
    /// Serializes GUID key into JSON byte array representation
    /// </summary>
    /// <param name="data">Key value to serialize</param>
    /// <param name="context">Serialization context provided by Kafka client</param>
    /// <returns>UTF8 JSON byte array</returns>
    public byte[] Serialize(Guid data, SerializationContext context) =>
        JsonSerializer.SerializeToUtf8Bytes(data);
}