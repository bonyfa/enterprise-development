using Hospital.Enums;

namespace Hospital.Models;

//<summary>
//Model that describe patient
//</summary>
public class Patient : Person
{   
    //<summary>
    //Blood group of the patient
    //</summary>
    public required BloodGroup BloodGroup { get; set; }
    
    //<summary>
    //Rhesus factor of the patient
    //</summary>
    public required RhesusFactor RhesusFactor { get; set; }
    
}