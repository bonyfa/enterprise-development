namespace Hospital.Models;

public class Person
{
    /// <summary>
    /// Unique ID of person (GUID)
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();
    
    /// <summary>
    /// Unique passport id of person
    /// </summary>
    public required int PassportId { get; set; }
    
    /// <summary>
    /// FullName of the person
    /// </summary>
    public required string FullName { get; set; }
    
    /// <summary>
    /// DateOfBirth of the person
    /// </summary>
    public required DateOnly DateOfBirth { get; set; }
    
}