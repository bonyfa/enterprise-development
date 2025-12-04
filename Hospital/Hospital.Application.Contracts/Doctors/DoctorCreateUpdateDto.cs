namespace Hospital.Application.Contracts.Doctors;

/// <summary>
/// DTO for creating or updating doctor data
/// </summary>
/// <param name="PassportId">Unique passport identifier of doctor</param>
/// <param name="FullName">Full name of doctor</param>
/// <param name="DateOfBirth">Date of birth of doctor</param>
/// <param name="SpecializationId">Foreign key identifier of doctor specialization</param>
/// <param name="WorkExperience">Work experience of doctor in years</param>
public sealed record DoctorCreateUpdateDto(
    int PassportId,
    string FullName,
    DateOnly DateOfBirth,
    Guid SpecializationId,
    int WorkExperience
);