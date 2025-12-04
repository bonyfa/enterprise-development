namespace Hospital.Models;

/// <summary>
/// Model that describe doctor
/// </summary>
public class Doctor : Person
{
    
    /// <summary>
    /// Specialization of doctor
    /// </summary>
    public required Specialization Specialization { get; set; }
    
    /// <summary>
    /// WorkExperience of doctor
    /// </summary>
    public required int WorkExperience { get; set; }
}