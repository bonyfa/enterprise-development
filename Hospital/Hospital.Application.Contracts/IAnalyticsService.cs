using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Patients;

namespace Hospital.Application.Contracts;

public interface IAnalyticsService
{
    /// <summary>
    /// Returns doctors with work experience greater than or equal to the specified value ordered by passport id
    /// </summary>
    /// <param name="minYears">Minimum work experience in years</param>
    /// <returns>List of doctors ordered by passport id</returns>
    public Task<IReadOnlyList<DoctorDto>> GetDoctorsByMinWorkExperienceAsync(int minYears);

    /// <summary>
    /// Returns patients who have appointments with the specified doctor ordered by full name
    /// </summary>
    /// <param name="doctorId">Doctor id</param>
    /// <returns>List of unique patients ordered by full name</returns>
    public Task<IReadOnlyList<PatientDto>> GetPatientsByDoctorIdOrderedByFullName(Guid doctorId);

    /// <summary>
    /// Counts repeated appointments within the specified inclusive date range
    /// </summary>
    /// <param name="from">Range start date and time inclusive</param>
    /// <param name="to">Range end date and time inclusive</param>
    /// <returns>Count of repeated appointments in range</returns>
    public Task<int> GetRepeatedAppointmentsCount(DateTime from, DateTime to);

    /// <summary>
    /// Returns passport ids of patients older than or equal to the specified age who have appointments with more than one distinct doctor ordered by passport id
    /// </summary>
    /// <param name="today">Current date used to calculate age</param>
    /// <param name="minAgeYears">Minimum age in years</param>
    /// <returns>List of patient passport ids ordered by passport id</returns>
    public Task<IReadOnlyList<int>> GetPatientPassportIdsOverAgeWithMultipleDoctors(DateOnly today, int minAgeYears);

    /// <summary>
    /// Returns appointment date and time values for a given office and month ordered by date and time
    /// </summary>
    /// <param name="officeNumber">Office number</param>
    /// <param name="year">Year of month</param>
    /// <param name="month">Month number 1 to 12</param>
    /// <returns>List of appointment date times ordered ascending</returns>
    public Task<IReadOnlyList<DateTime>> GetAppointmentTimesByOfficeInMonth(int officeNumber, int year, int month);
}
