using Hospital.Application.Contracts.Appointments;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Host.Controllers;

/// <summary>
/// Controller that provides CRUD endpoints for appointments
/// </summary>
/// <param name="service">Application service for appointment CRUD operations</param>
/// <param name="logger">Logger instance</param>
[Route("api/[controller]")]
[ApiController]
public class AppointmentController(IAppointmentService service, ILogger<AppointmentController> logger)
    : CrudControllerBase<AppointmentDto, AppointmentCreateUpdateDto, Guid>(service, logger);
