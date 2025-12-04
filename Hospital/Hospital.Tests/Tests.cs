using Xunit;

namespace Hospital.Tests;

/// <summary>
/// Tests to verify the functionality of models 
/// </summary>
public class HospitalDomainTests(HospitalDataFixture fixture) : IClassFixture<HospitalDataFixture>
{
    /// <summary>
    /// Tests to verify retrieving doctors with work experience of 10 years or more
    /// </summary>
    [Fact]
    public void GetDoctors_WithWorkExperienceOver10Years_ReturnsCorrectDoctors()
    {
        var expectedCount = 9;
        var expectedFirstDoctorPassportId = 45112233; // Первый элемент после сортировки
        
        var resultDoctors = fixture.Doctors
            .Where(d => d.WorkExperience >= 10)
            .OrderBy(d => d.PassportId)
            .ToList();
        
        Assert.Equal(expectedCount, resultDoctors.Count);
        Assert.Equal(expectedFirstDoctorPassportId, resultDoctors[0].PassportId);
    }

    /// <summary>
    /// Tests to verify retrieving patients for specific doctor ordered by full name
    /// </summary>
    [Fact]
    public void GetPatients_ByDoctorIdOrderedByFullName_ReturnsCorrectPatients()
    {
        // Arrange
        var doctorPassportId = 45112233; // Смирнов Александр
        var expectedCount = 2; // 2 пациента (Иванов и Сидоров)
        var expectedFirstPatientName = "Иванов Иван Иванович"; // Первый пациент после сортировки по ФИО

        var doctorId = fixture.Doctors.Single(d => d.PassportId == doctorPassportId).Id;

        // Act
        var patientIds = fixture.Appointments
        .Where(a => a.DoctorId == doctorId)
        .Select(a => a.PatientId)
        .Distinct()
        .ToList();

        var patients = fixture.Patients
            .Where(p => patientIds.Contains(p.Id))
            .OrderBy(p => p.FullName)
            .ToList();

        // Assert
        // 1. Проверяем число элементов в коллекции
        Assert.Equal(expectedCount, patients.Count);
    
        // 2. Проверяем вхождение первого конкретного элемента в отсортированной коллекции
        Assert.Equal(expectedFirstPatientName, patients[0].FullName);
    }

    /// <summary>
    /// Tests to verify counting repeated appointments in the last month
    /// </summary>
    [Fact]
    public void GetRepeatedAppointments_LastMonth_ReturnsCorrectCount()
    {
        var today = new DateTime(2025, 1, 31);
        var monthAgo = today.AddMonths(-1);
        var expectedDateTime = new DateTime(2025, 1, 15, 10, 30, 0);
        
        var result = fixture.Appointments
            .Count(a => a.IsRepeated && a.DateAndTime >= monthAgo && a.DateAndTime <= today);
        
        Assert.Equal(6, result);
        Assert.Equal(expectedDateTime, fixture.Appointments[1].DateAndTime);
    }

    /// <summary>
    /// Tests to verify retrieving patients over 30 years old with appointments to multiple doctors ordered by birth date
    /// </summary>
    [Fact]
    public void GetPatients_Over30WithMultipleDoctors_ReturnsCorrectPatientsOrderedByBirthDate()
    {
        var today = new DateOnly(2025, 1, 31);
        var ageLimit = today.AddYears(-30); // 1995 год и старше

        var eligiblePatientIds = fixture.Patients
        .Where(p => p.DateOfBirth <= ageLimit)
        .Select(p => p.Id)
        .ToHashSet();

        var resultPatientIds = fixture.Appointments
            .Where(a => eligiblePatientIds.Contains(a.PatientId))
            .GroupBy(a => a.PatientId)
            .Where(g => g.Select(a => a.DoctorId).Distinct().Count() > 1)
            .Select(g => g.Key)
            .ToList();

        var resultPassportIds = fixture.Patients
            .Where(p => resultPatientIds.Contains(p.Id))
            .Select(p => p.PassportId)
            .OrderBy(id => id)
            .ToList();

        List<int> expectedPassportIds = [45123456, 45567890, 45789012];
        Assert.Equal(expectedPassportIds, resultPassportIds);
    }

    /// <summary>
    /// Tests to verify retrieving appointments in current month for specific office
    /// </summary>
    [Fact]
    public void GetAppointments_CurrentMonthByOffice_ReturnsCorrectAppointments()
    {
        // Arrange
        var today = new DateTime(2025, 1, 31);
        var officeNumber = 101;
        
        // Act
        var resultAppointmentTimes = fixture.Appointments
            .Where(a => a.NumberOfOffice == officeNumber
                        && a.DateAndTime.Year == today.Year
                        && a.DateAndTime.Month == today.Month)
            .OrderBy(a => a.DateAndTime)
            .Select(a => a.DateAndTime)
            .ToList();
        
        // Assert - в кабинете 101 в январе 2 приема
        List<DateTime> expectedAppointmentTimes = [
            new DateTime(2025, 1, 15, 9, 0, 0),
            new DateTime(2025, 1, 20, 11, 0, 0)
        ];
        Assert.Equal(expectedAppointmentTimes, resultAppointmentTimes);
    }
}