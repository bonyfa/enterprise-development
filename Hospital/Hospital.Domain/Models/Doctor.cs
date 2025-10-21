namespace Hospital.Models;

//<summary>
//Model that describe doctor
//</summary>
public class Doctor
{
    //<summary>
    //Uniq passport id of doctor
    //</summary>
    public required int PassportId { get; set; }
    
    //<summary>
    //FullName of doctor
    //</summary>
    public required string FullName { get; set; }
    
    //<summary>
    //DateOfBirth of doctor
    //</summary>
    public required DateTime DateOfBirth { get; set; }
    
    //<summary>
    //Specialization of doctor
    //</summary>
    public required Specialization Specialization { get; set; }
    
    //<summary>
    //WorkExperience of doctor
    //</summary>
    public required int WorkExperience { get; set; }
}