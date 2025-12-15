namespace Hospital.Application.Contracts;

/// <summary>
/// DTO that contains only the entity identifier
/// </summary>
/// <param name="Id">Unique identifier of the entity</param>
public sealed record EntityIdDto(Guid Id);