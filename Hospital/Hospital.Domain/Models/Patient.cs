using Hospital.Enums;

namespace Hospital.Models;

//<summary>
//Model that describe patient
//</summary>
public class Patient : Person
{   
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
    
    //<summary>
    //Blood group of the patient
    //</summary>
    public required BloodGroup BloodGroup { get; set; }
    
    //<summary>
    //Rhesus factor of the patient
    //</summary>
    public required RhesusFactor RhesusFactor { get; set; }
    
}