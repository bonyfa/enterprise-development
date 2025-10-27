using Hospital.Enums;

namespace Hospital.Models;

public class Person
{
    /// <summary>
    /// Unique ID of person (GUID)
    /// </summary>
    public required Guid Id { get; set; } = Guid.NewGuid();
    
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
    
    /// <summary>
    /// Phone number of the person
    /// </summary>
    public string? PhoneNumber { get; set; }
    
    //<summary>
    //FullName of person
    //</summary>
    public Gender? Gender { get; set; }
    
    //<summary>
    //Address of the person
    //</summary>
    public string? Address { get; set; }
}