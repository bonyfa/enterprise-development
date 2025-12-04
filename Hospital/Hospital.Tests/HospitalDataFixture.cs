using Hospital.DataInitialization;
using Hospital.Models;

namespace Hospital.Tests;

/// <summary>
/// Provides a pre-initialized set of Hospital data for testing
/// </summary>
public class HospitalDataFixture
{
    /// <summary>
    /// A list of test patients
    /// </summary>
    public List<Patient> Patients { get; }
    /// <summary>
    /// A list of test doctors
    /// </summary>
    public List<Doctor> Doctors { get; }
    /// <summary>
    /// A list of test appointments
    /// </summary>
    public List<Appointment> Appointments { get; }

    /// <summary>
    /// Initializes the fixture by loading data from the Initialization class
    /// </summary>
    public HospitalDataFixture()
    {
        Patients = Initialization.Patients;
        Doctors = Initialization.Doctors;
        Appointments = Initialization.Appointments;
    }
}