namespace Hospital.Application.Contracts.Specializations;

/// <summary>
/// DTO for creating or updating specialization data
/// </summary>
/// <param name="Name">Name of specialization</param>
public sealed record SpecializationCreateUpdateDto(
    string Name
);