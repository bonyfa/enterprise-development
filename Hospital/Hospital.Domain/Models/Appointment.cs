namespace Hospital.Models;

//<summary>
//Model that describe an Appointment
//</summary>
public class Appointment
{
    //<summary>
    //Id of appointment
    //</summary>
    public required int Id { get; set; }
    
    //<summary>
    //Date and time of appointment
    //</summary>
    public required DateTime DateAndTime { get; set; }
    
    //<summary>
    //Number of office
    //</summary>
    public required int NumberOfOffice { get; set; }
    
    //<summary>
    //First or not appointment
    //</summary>
    public required bool IsRepeated { get; set; }
    
    //<summary>
    //Patient with an appointment 
    //</summary>
    public required Patient Patient { get; set; }
    
    //<summary>
    //Doctor receiving an appointment
    //</summary>
    public required Doctor Doctor { get; set; }
}