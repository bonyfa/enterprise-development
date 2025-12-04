using Hospital.Domain.Shared.Enums;

namespace Hospital.Application.Contracts.Patients;

/// <summary>
/// DTO for creating or updating patient data
/// </summary>
/// <param name="PassportId">Unique passport identifier of patient</param>
/// <param name="FullName">Full name of patient</param>
/// <param name="DateOfBirth">Date of birth of patient</param>
/// <param name="PhoneNumber">Phone number of patient</param>
/// <param name="Gender">Gender of patient</param>
/// <param name="Address">Home address of patient</param>
/// <param name="BloodGroup">Blood group of patient</param>
/// <param name="RhesusFactor">Rhesus factor of patient</param>
public sealed record PatientCreateUpdateDto(
    int PassportId,
    string FullName,
    DateOnly DateOfBirth,
    string? PhoneNumber,
    Gender? Gender,
    string? Address,
    BloodGroup BloodGroup,
    RhesusFactor RhesusFactor
);