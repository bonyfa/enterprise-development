namespace Hospital.Models;

/// <summary>
/// Model that describe doctor
/// </summary>
public class Doctor : Person
{
    /// <summary>
    /// Foreign key to Specialization
    /// </summary>
    public required Guid SpecializationId { get; set; }

    /// <summary>
    /// Specialization of doctor
    /// </summary>
    public Specialization? Specialization { get; set; }
    
    /// <summary>
    /// WorkExperience of doctor
    /// </summary>
    public required int WorkExperience { get; set; }
}