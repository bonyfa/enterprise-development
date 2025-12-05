using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Patients;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Host.Controllers;

/// <summary>
/// Controller that exposes analytics endpoints according to the assignment requirements
/// </summary>
/// <param name="service">Analytics service instance</param>
/// <param name="logger">Logger instance</param>
[Route("api/[controller]")]
[ApiController]
public sealed class AnalyticsController(IAnalyticsService service, ILogger<AnalyticsController> logger) : ControllerBase
{
    /// <summary>
    /// Returns all doctors with work experience at least 10 years ordered by passport id
    /// </summary>
    /// <returns>List of doctors</returns>
    [HttpGet("doctors-experience>=10")]
    [ProducesResponseType(typeof(IReadOnlyList<DoctorDto>), 200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IReadOnlyList<DoctorDto>>> GetDoctorsWithExperienceAtLeast10()
    {
        logger.LogInformation("{method} called", nameof(GetDoctorsWithExperienceAtLeast10));
        try
        {
            var result = await service.GetDoctorsByMinWorkExperience(10);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception in {method}", nameof(GetDoctorsWithExperienceAtLeast10));
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Returns all patients who have appointments with specified doctor ordered by full name
    /// </summary>
    /// <param name="doctorId">Doctor identifier</param>
    /// <returns>List of patients ordered by full name</returns>
    [HttpGet("patients-by-doctor-id/{doctorId}")]
    [ProducesResponseType(typeof(IReadOnlyList<PatientDto>), 200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IReadOnlyList<PatientDto>>> GetPatientsByDoctor([FromRoute] Guid doctorId)
    {
        logger.LogInformation("{method} called with doctorId={doctorId}", nameof(GetPatientsByDoctor), doctorId);
        try
        {
            var result = await service.GetPatientsByDoctorIdOrderedByFullName(doctorId);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception in {method}", nameof(GetPatientsByDoctor));
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Returns count of repeated appointments during last month relative to current date
    /// </summary>
    /// <returns>Count of repeated appointments</returns>
    [HttpGet("appointments-repeated-last-month/count")]
    [ProducesResponseType(typeof(int), 200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<int>> GetRepeatedAppointmentsCountLastMonth()
    {
        logger.LogInformation("{method} called", nameof(GetRepeatedAppointmentsCountLastMonth));
        try
        {
            var to = DateTime.UtcNow;
            var from = to.AddMonths(-1);

            var result = await service.GetRepeatedAppointmentsCount(from, to);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception in {method}", nameof(GetRepeatedAppointmentsCountLastMonth));
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Returns patients older than 30 years who have appointments with multiple doctors ordered by date of birth
    /// </summary>
    /// <returns>List of patients ordered by date of birth</returns>
    [HttpGet("patients-over-30-multiple-doctors")]
    [ProducesResponseType(typeof(IReadOnlyList<PatientDto>), 200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IReadOnlyList<PatientDto>>> GetPatientsOver30WithMultipleDoctors()
    {
        logger.LogInformation("{method} called", nameof(GetPatientsOver30WithMultipleDoctors));
        try
        {
            var today = DateOnly.FromDateTime(DateTime.UtcNow);
            var result = await service.GetPatientsOverAgeWithMultipleDoctors(today, 30);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception in {method}", nameof(GetPatientsOver30WithMultipleDoctors));
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Returns appointments for current month in specified office ordered by date and time
    /// </summary>
    /// <param name="officeNumber">Office number</param>
    /// <returns>List of appointments ordered by date and time</returns>
    [HttpGet("appointments-current-month-by-office/{officeNumber}")]
    [ProducesResponseType(typeof(IReadOnlyList<AppointmentDto>), 200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IReadOnlyList<AppointmentDto>>> GetAppointmentsCurrentMonthByOffice([FromRoute] int officeNumber)
    {
        logger.LogInformation("{method} called with officeNumber={officeNumber}", nameof(GetAppointmentsCurrentMonthByOffice), officeNumber);
        try
        {
            var now = DateTime.UtcNow;
            var result = await service.GetAppointmentsByOfficeInMonth(officeNumber, now.Year, now.Month);
            return Ok(result);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Exception in {method}", nameof(GetAppointmentsCurrentMonthByOffice));
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}
