namespace Hospital.Models;

//<summary>
//Model that describe Specialization
//</summary>
public class Specialization
{
    /// <summary>
    /// Unique ID of Specialization (GUID)
    /// </summary>
    public required Guid Id { get; set; } = Guid.NewGuid();
    
    //<summary>
    //Name and key of Specialization
    //</summary>
    public required string Name { get; set; }
}