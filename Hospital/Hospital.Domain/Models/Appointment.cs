namespace Hospital.Models;

/// <summary>
/// Model that describe an Appointment
/// </summary>
public class Appointment
{
    /// <summary>
    /// Unique ID of appointment (GUID)
    /// </summary>
    public required Guid Id { get; set; } = Guid.NewGuid();
    
    /// <summary>
    /// Date and time of appointment
    /// </summary>
    public required DateTime DateAndTime { get; set; }
    
    /// <summary>
    /// Number of office
    /// </summary>
    public required int NumberOfOffice { get; set; }
    
    /// <summary>
    /// First or not appointment
    /// </summary>
    public required bool IsRepeated { get; set; }

    /// <summary>
    /// Foreign key to Patient
    /// </summary>
    public required Guid PatientId { get; set; }

    /// <summary>
    /// Foreign key to Doctor
    /// </summary>
    public required Guid DoctorId { get; set; }

    /// <summary>
    /// Patient with an appointment 
    /// </summary>
    public Patient? Patient { get; set; }

    /// <summary>
    /// Doctor receiving an appointment
    /// </summary>
    public Doctor? Doctor { get; set; }
}