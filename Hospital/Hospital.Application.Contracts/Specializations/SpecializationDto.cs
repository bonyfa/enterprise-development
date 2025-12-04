namespace Hospital.Application.Contracts.Specializations;

/// <summary>
/// DTO for returning specialization data
/// </summary>
/// <param name="Id">Unique identifier of specialization</param>
/// <param name="Name">Name of specialization</param>
public sealed record SpecializationDto(
    Guid Id,
    string Name
);