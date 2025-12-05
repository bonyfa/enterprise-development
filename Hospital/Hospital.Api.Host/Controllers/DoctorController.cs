using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Specializations;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Host.Controllers;

/// <summary>
/// Controller that provides CRUD endpoints for doctors and doctor related queries
/// </summary>
/// <param name="service">Application service for doctor CRUD operations</param>
/// <param name="appointmentService">Application service used to query doctor appointments</param>
/// <param name="logger">Logger instance</param>
[Route("api/[controller]")]
[ApiController]
public class DoctorController(
    IDoctorService service,
    IAppointmentService appointmentService,
    ILogger<DoctorController> logger)
    : CrudControllerBase<DoctorDto, DoctorCreateUpdateDto, Guid>(service, logger)
{
    /// <summary>
    /// Returns specialization for the specified doctor
    /// </summary>
    /// <param name="id">Doctor identifier</param>
    /// <returns>Doctor specialization</returns>
    [HttpGet("{id}/Specialization")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<SpecializationDto>> GetSpecialization(Guid id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(GetSpecialization), GetType().Name, id);
        try
        {
            var res = await service.GetSpecialization(id);
            logger.LogInformation("{method} method of {controller} executed successfully", nameof(GetSpecialization), GetType().Name);
            return Ok(res);
        }
        catch (KeyNotFoundException ex)
        {
            logger.LogWarning("A not found exception happened during {method} method of {controller}: {@exception}", nameof(GetSpecialization), GetType().Name, ex);
            return NotFound($"{ex.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError("An exception happened during {method} method of {controller}: {@exception}", nameof(GetSpecialization), GetType().Name, ex);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    /// <summary>
    /// Returns appointments for the specified doctor
    /// </summary>
    /// <param name="id">Doctor identifier</param>
    /// <returns>List of appointments for the specified doctor</returns>
    [HttpGet("{id}/Appointments")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<AppointmentDto>>> GetAppointments(Guid id)
    {
        logger.LogInformation("{method} method of {controller} is called with {id} parameter", nameof(GetAppointments), GetType().Name, id);
        try
        {
            var res = await appointmentService.GetAppointmentsByDoctorId(id);
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