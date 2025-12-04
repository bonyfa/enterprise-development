using AutoMapper;
using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Patients;
using Hospital.Models;

namespace Hospital.Application.Services;

/// <summary>
/// Application service that provides CRUD operations for patients
/// </summary>
/// <param name="repository">Repository for patient entities</param>
/// <param name="mapper">AutoMapper instance used to map between entities and DTOs</param>
public sealed class PatientService(IRepository<Patient, Guid> repository, IMapper mapper)
    : IApplicationService<PatientDto, PatientCreateUpdateDto, Guid>
{
    /// <inheritdoc />
    public async Task<PatientDto> Create(PatientCreateUpdateDto dto)
    {
        var entity = mapper.Map<Patient>(dto);
        var created = await repository.Create(entity);
        return mapper.Map<PatientDto>(created);
    }

    /// <inheritdoc />
    public async Task<PatientDto?> Get(Guid dtoId)
    {
        var entity = await repository.Read(dtoId);
        return mapper.Map<PatientDto>(entity);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<PatientDto>> GetAll()
    {
        var entities = await repository.ReadAll();
        return mapper.Map<IReadOnlyList<PatientDto>>(entities);
    }

    /// <inheritdoc />
    public async Task<PatientDto> Update(PatientCreateUpdateDto dto, Guid dtoId)
    {
        var existing = await repository.Read(dtoId) ?? throw new KeyNotFoundException($"Patient with id {dtoId} not found");
        mapper.Map(dto, existing);
        var updated = await repository.Update(existing);

        return mapper.Map<PatientDto>(updated);
    }

    /// <inheritdoc />
    public Task<bool> Delete(Guid dtoId) => repository.Delete(dtoId);
}