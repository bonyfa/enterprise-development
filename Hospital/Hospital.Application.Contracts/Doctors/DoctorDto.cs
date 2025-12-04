namespace Hospital.Application.Contracts.Doctors;

/// <summary>
/// DTO for returning doctor data
/// </summary>
/// <param name="Id">Unique identifier of doctor</param>
/// <param name="PassportId">Unique passport identifier of doctor</param>
/// <param name="FullName">Full name of doctor</param>
/// <param name="DateOfBirth">Date of birth of doctor</param>
/// <param name="WorkExperience">Work experience of doctor in years</param>
public sealed record DoctorDto(
    Guid Id,
    int PassportId,
    string FullName,
    DateOnly DateOfBirth,
    int WorkExperience
);