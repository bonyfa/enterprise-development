namespace Hospital.Application.Contracts.Appointments;

/// <summary>
/// DTO for returning appointment data
/// </summary>
/// <param name="Id">Unique identifier of appointment</param>
/// <param name="DateAndTime">Date and time of appointment</param>
/// <param name="NumberOfOffice">Office number for appointment</param>
/// <param name="IsRepeated">Indicates whether appointment is repeated</param>
/// <param name="PatientId">Foreign key identifier of patient</param>
/// <param name="DoctorId">Foreign key identifier of doctor</param>
public sealed record AppointmentDto(
    Guid Id,
    DateTime DateAndTime,
    int NumberOfOffice,
    bool IsRepeated,
    Guid PatientId,
    Guid DoctorId
);