using Hospital.Enums;

namespace Hospital.Models;

//<summary>
//Model that describe patient
//</summary>
public class Patient
{
    //<summary>
    //Uniq passport id of patient
    //</summary>
    public required int PassportId { get; set; }
    
    //<summary>
    //FullName of the patient
    //</summary>
    public required string FullName { get; set; } 
    
    //<summary>
    //FullName of the patient
    //</summary>
    public required Gender Gender { get; set; }
    
    //<summary>
    //DateOfBirth of the patient
    //</summary>
    public required DateTime DateOfBirth { get; set; }
    
    //<summary>
    //Address of the patient
    //</summary>
    public required string Address { get; set; }
    
    //<summary>
    //Blood group of the patient
    //</summary>
    public required BloodGroup BloodGroup { get; set; }
    
    //<summary>
    //Rhesus factor of the patient
    //</summary>
    public required RhesusFactor RhesusFactor { get; set; }
    
    //<summary>
    //Phone number of the patient
    //</summary>
    public required string PhoneNumber { get; set; }
}