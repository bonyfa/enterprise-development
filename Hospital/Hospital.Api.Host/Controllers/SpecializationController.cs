using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Specializations;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Api.Host.Controllers;

/// <summary>
/// Controller that provides CRUD endpoints for specializations
/// </summary>
/// <param name="service">Application service for specialization CRUD operations</param>
/// <param name="logger">Logger instance</param>
[Route("api/[controller]")]
[ApiController]
public class SpecializationController(
    IApplicationService<SpecializationDto, SpecializationCreateUpdateDto, Guid> service,
    ILogger<SpecializationController> logger)
    : CrudControllerBase<SpecializationDto, SpecializationCreateUpdateDto, Guid>(service, logger);
