using Hospital.DataInitialization;
using Hospital.Models;
using Xunit;

namespace Hospital.Tests;

//<summary>
//Tests to verify the functionality of models 
//</summary>
public class HospitalDomainTests
{
    private readonly List<Patient> _patients = Initialization.Patients;
    private readonly List<Doctor> _doctors = Initialization.Doctors;
    private readonly List<Appointment> _appointments = Initialization.Appointments;
    
    /// <summary>
    /// Tests to verify retrieving doctors with work experience of 10 years or more
    /// </summary>
    [Fact]
    public void GetDoctors_WithWorkExperienceOver10Years_ReturnsCorrectDoctors()
    {
        List<int> expectedPassportIds = [
            45112233, 45445566, 45778899, 45123450, 45234561,
            45345672, 45456783, 45678905, 45789016
        ];
        
        var resultPassportIds = _doctors
            .Where(d => d.WorkExperience >= 10)
            .OrderBy(d => d.PassportId)  
            .Select(d => d.PassportId)
            .ToList();
        
        Assert.Equal(expectedPassportIds.OrderBy(x => x), resultPassportIds.OrderBy(x => x));
    }

    /// <summary>
    /// Tests to verify retrieving patients for specific doctor ordered by full name
    /// </summary>
    [Theory]
    [InlineData(45112233, 1)]
    [InlineData(45445566, 1)]
    [InlineData(45778899, 1)]
    public void GetPatients_ByDoctorIdOrderedByFullName_ReturnsCorrectPatients(int doctorPassportId, int expectedCount)
    {
        var patients = _appointments
            .Where(a => a.Doctor.PassportId == doctorPassportId)
            .Select(a => a.Patient)
            .OrderBy(p => p.FullName)
            .ToList();
        
        Assert.Equal(expectedCount, patients.Count);
    }

    /// <summary>
    /// Tests to verify counting repeated appointments in the last month
    /// </summary>
    [Fact]
    public void GetRepeatedAppointments_LastMonth_ReturnsCorrectCount()
    {
        var today = new DateTime(2025, 10, 25);
        var monthAgo = today.AddMonths(-1);
        
        var result = _appointments
            .Count(a => a.IsRepeated && a.DateAndTime >= monthAgo && a.DateAndTime <= today);
        
        Assert.Equal(5, result);
    }

    /// <summary>
    /// Tests to verify retrieving patients over 30 years old with appointments to multiple doctors ordered by birth date
    /// </summary>
    [Fact]
    public void GetPatients_Over30WithMultipleDoctors_ReturnsCorrectPatientsOrderedByBirthDate()
    {
        var today = new DateTime(2025, 1, 31);
        var ageLimit = today.AddYears(-30);
        
        var resultPassportIds = _appointments
            .Where(a => a.Patient.DateOfBirth <= ageLimit)
            .GroupBy(a => a.Patient.PassportId)
            .Where(g => g.Select(a => a.Doctor.PassportId).Distinct().Count() > 1)
            .Select(g => g.Key)
            .OrderBy(id => id)
            .ToList();
        
        Assert.Empty(resultPassportIds);
    }

    /// <summary>
    /// Tests to verify retrieving appointments in current month for specific office
    /// </summary>
    [Fact]
    public void GetAppointments_CurrentMonthByOffice_ReturnsCorrectAppointments()
    {
        var today = new DateTime(2025, 1, 31);
        var officeNumber = 101;
        
        var resultAppointmentTimes = _appointments
            .Where(a => a.NumberOfOffice == officeNumber
                        && a.DateAndTime.Year == today.Year
                        && a.DateAndTime.Month == today.Month)
            .OrderBy(a => a.DateAndTime)
            .Select(a => a.DateAndTime)
            .ToList();
        
        Assert.Single(resultAppointmentTimes);
        Assert.Equal(new DateTime(2025, 1, 15, 9, 0, 0), resultAppointmentTimes[0]);
    }
}