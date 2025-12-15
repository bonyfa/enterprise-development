using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Appointments;
using Hospital.Generator.Kafka.Host.Generator;
using Hospital.Generator.Kafka.Host.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Generator.Kafka.Host.Controllers;

/// <summary>
/// Controller used to generate appointment contracts and publish them via message broker
/// </summary>
/// <param name="logger">Logger instance</param>
/// <param name="producerService">Producer service used to send contracts</param>
/// <param name="httpClientFactory">HTTP client factory used to query Hospital API for existing identifiers</param>
/// <param name="configuration">Configuration instance used to read generator settings</param>
[Route("api/[controller]")]
[ApiController]
public sealed class GeneratorController(
    ILogger<GeneratorController> logger,
    IProducerService producerService,
    IHttpClientFactory httpClientFactory,
    IConfiguration configuration) : ControllerBase
{
    /// <summary>
    /// Generates appointment contracts and sends them via broker using batches and delay between sends
    /// </summary>
    /// <param name="batchSize">Batch size</param>
    /// <param name="payloadLimit">Total number of contracts to send</param>
    /// <param name="waitTime">Delay in seconds between batches</param>
    /// <returns>List of generated contracts</returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<List<AppointmentCreateUpdateDto>>> Get(
        [FromQuery] int batchSize,
        [FromQuery] int payloadLimit,
        [FromQuery] int waitTime)
    {
        logger.LogInformation("Generating {limit} contracts via {batchSize} batches and {waitTime}s delay", payloadLimit, batchSize, waitTime);

        try
        {
            var (patientIds, doctorIds) = await GetIdPools();

            if (patientIds.Count == 0 || doctorIds.Count == 0)
                return StatusCode(500, "No patientIds or doctorIds available for generation");

            var list = new List<AppointmentCreateUpdateDto>(payloadLimit);

            var counter = 0;
            while (counter < payloadLimit)
            {
                var currentBatchSize = Math.Min(batchSize, payloadLimit - counter);

                var batch = AppointmentGenerator.GenerateContracts(
                    count: currentBatchSize,
                    patientIds: patientIds,
                    doctorIds: doctorIds);

                await producerService.SendAsync(batch);

                logger.LogInformation("Batch of {batchSize} items has been sent", currentBatchSize);

                counter += currentBatchSize;
                list.AddRange(batch);

                if (counter < payloadLimit && waitTime > 0)
                    await Task.Delay(waitTime * 1000);
            }

            logger.LogInformation("{method} method of {controller} executed successfully", nameof(Get), GetType().Name);
            return Ok(list);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception happened during {method} method of {controller}", nameof(Get), GetType().Name);
            return StatusCode(500, $"{ex.Message}\n\r{ex.InnerException?.Message}");
        }
    }

    private async Task<(IList<Guid> patientIds, IList<Guid> doctorIds)> GetIdPools()
    {
        var seedPatientIds = configuration.GetSection("Generator:SeedPatientIds").Get<List<Guid>>() ?? [];
        var seedDoctorIds = configuration.GetSection("Generator:SeedDoctorIds").Get<List<Guid>>() ?? [];

        var baseUrl = configuration["Generator:ApiBaseUrl"];
        if (string.IsNullOrWhiteSpace(baseUrl))
        {
            logger.LogWarning("Generator:ApiBaseUrl is not configured, falling back to seed ids");
            return (seedPatientIds, seedDoctorIds);
        }

        var patientsPath = configuration["Generator:PatientsPath"] ?? "api/Patient";
        var doctorsPath = configuration["Generator:DoctorsPath"] ?? "api/Doctor";

        try
        {
            var client = httpClientFactory.CreateClient("hospital-api");

            var patients = await client.GetFromJsonAsync<List<EntityIdDto>>(patientsPath) ?? [];
            var doctors = await client.GetFromJsonAsync<List<EntityIdDto>>(doctorsPath) ?? [];

            var patientIds = patients.Select(x => x.Id).Distinct().ToList();
            var doctorIds = doctors.Select(x => x.Id).Distinct().ToList();

            if (patientIds.Count == 0 || doctorIds.Count == 0)
            {
                logger.LogWarning("Hospital API returned empty id pools, falling back to seed ids");
                return (seedPatientIds, seedDoctorIds);
            }

            return (patientIds, doctorIds);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Failed to load id pools from Hospital API, falling back to seed ids");
            return (seedPatientIds, seedDoctorIds);
        }
    }
}