using AutoMapper;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Specializations;
using Hospital.Models;

namespace Hospital.Application.Services;

/// <summary>
/// Application service that provides CRUD operations for doctors and doctor specialization query
/// </summary>
/// <param name="doctorRepository">Repository for doctor entities</param>
/// <param name="specializationRepository">Repository for specialization entities</param>
/// <param name="mapper">AutoMapper instance used to map between entities and DTOs</param>
public sealed class DoctorService(
    IRepository<Doctor, Guid> doctorRepository,
    IRepository<Specialization, Guid> specializationRepository,
    IMapper mapper
) : IDoctorService
{
    /// <inheritdoc />
    public async Task<DoctorDto> Create(DoctorCreateUpdateDto dto)
    {
        _ = await specializationRepository.Read(dto.SpecializationId) ?? throw new KeyNotFoundException($"Specialization with id {dto.SpecializationId} not found");
        var entity = mapper.Map<Doctor>(dto);
        var created = await doctorRepository.Create(entity);

        return mapper.Map<DoctorDto>(created);
    }

    /// <inheritdoc />
    public async Task<DoctorDto?> Get(Guid dtoId)
    {
        var entity = await doctorRepository.Read(dtoId);
        return mapper.Map<DoctorDto>(entity);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<DoctorDto>> GetAll()
    {
        var entities = await doctorRepository.ReadAll();
        return mapper.Map<IReadOnlyList<DoctorDto>>(entities);
    }

    /// <inheritdoc />
    public async Task<DoctorDto> Update(DoctorCreateUpdateDto dto, Guid dtoId)
    {
        var existing = await doctorRepository.Read(dtoId) ?? throw new KeyNotFoundException($"Doctor with id {dtoId} not found");
        _ = await specializationRepository.Read(dto.SpecializationId) ?? throw new KeyNotFoundException($"Specialization with id {dto.SpecializationId} not found");
        mapper.Map(dto, existing);
        var updated = await doctorRepository.Update(existing);

        return mapper.Map<DoctorDto>(updated);
    }

    /// <inheritdoc />
    public Task<bool> Delete(Guid dtoId) => doctorRepository.Delete(dtoId);

    /// <inheritdoc />
    public async Task<SpecializationDto> GetSpecialization(Guid doctorId)
    {
        var doctor = await doctorRepository.Read(doctorId) ?? throw new KeyNotFoundException($"Doctor with id {doctorId} not found");
        var spec = await specializationRepository.Read(doctor.SpecializationId);
        return spec is null
            ? throw new KeyNotFoundException($"Specialization with id {doctor.SpecializationId} not found")
            : mapper.Map<SpecializationDto>(spec);
    }
}