namespace Hospital.Models;

using Hospital.Enums;

//<summary>
//Model that describe patient
//</summary>
public class Patient
{
    //<summary>
    //Uniq passport id of patient
    //</summary>
    public required int PassportId;
    
    //<summary>
    //FullName of the patient
    //</summary>
    public required string FullName;
    
    //<summary>
    //FullName of the patient
    //</summary>
    public required Gender Gender;
    
    //<summary>
    //DateOfBirth of the patient
    //</summary>
    public required DateTime DateOfBirth;
    
    //<summary>
    //Address of the patient
    //</summary>
    public required string Address;
    
    //<summary>
    //Blood group of the patient
    //</summary>
    public required BloodGroup BloodGroup;
    
    //<summary>
    //Rhesus factor of the patient
    //</summary>
    public required RhesusFactor RhesusFactor;
    
    //<summary>
    //Phone number of the patient
    //</summary>
    public required string PhoneNumber;
}