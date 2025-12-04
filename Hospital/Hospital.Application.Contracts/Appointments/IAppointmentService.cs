namespace Hospital.Application.Contracts.Appointments;

/// <summary>
/// Application service for managing appointments and appointment queries
/// </summary>
public interface IAppointmentService : IApplicationService<AppointmentDto, AppointmentCreateUpdateDto, Guid>
{
    /// <summary>
    /// Returns appointments for a specified doctor
    /// </summary>
    /// <param name="doctorId">Doctor identifier</param>
    /// <returns>List of appointments for the specified doctor</returns>
    public Task<IList<AppointmentDto>> GetAppointmentsByDoctorId(Guid doctorId);

    /// <summary>
    /// Returns appointments for a specified patient
    /// </summary>
    /// <param name="patientId">Patient identifier</param>
    /// <returns>List of appointments for the specified patient</returns>
    public Task<IList<AppointmentDto>> GetAppointmentsByPatientId(Guid patientId);
}