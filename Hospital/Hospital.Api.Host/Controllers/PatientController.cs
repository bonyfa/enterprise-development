using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Patients;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Host.Controllers;

/// <summary>
/// Controller that provides CRUD endpoints for patients and patient related queries
/// </summary>
/// <param name="service">Application service for patient CRUD operations</param>
/// <param name="appointmentService">Application service used to query patient appointments</param>
/// <param name="logger">Logger instance</param>
[Route("api/[controller]")]
[ApiController]
public class PatientController(
    IApplicationService<PatientDto, PatientCreateUpdateDto, Guid> service,
    IAppointmentService appointmentService,
    ILogger<PatientController> logger)
    : CrudControllerBase<PatientDto, PatientCreateUpdateDto, Guid>(service, logger)
{
    /// <summary>
    /// Returns appointments for the specified patient
    /// </summary>
    /// <param name="id">Patient identifier</param>
    /// <returns>List of appointments for the specified patient</returns>
    [HttpGet("{id}/Appointments")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<AppointmentDto>>> GetAppointments(Guid id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(GetAppointments), GetType().Name, id);
        try
        {
            var res = await appointmentService.GetAppointmentsByPatientId(id);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetAppointments), GetType().Name);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogWarning("A not found exception happened during {method} method of {controller}: {@exception}", nameof(GetAppointments), GetType().Name, ex);
            return NotFound($"{ex.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetAppointments), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }
}