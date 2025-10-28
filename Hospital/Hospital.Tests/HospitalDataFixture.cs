using Hospital.DataInitialization;
using Hospital.Models;


public class HospitalDataFixture
{
    public List<Patient> Patients { get; }
    public List<Doctor> Doctors { get; }
    public List<Appointment> Appointments { get; }

    public HospitalDataFixture()
    {
        Patients = Initialization.Patients;
        Doctors = Initialization.Doctors;
        Appointments = Initialization.Appointments;
    }
}