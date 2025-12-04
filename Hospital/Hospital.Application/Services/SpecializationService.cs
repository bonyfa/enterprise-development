using AutoMapper;
using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Specializations;
using Hospital.Models;

namespace Hospital.Application.Services;

/// <summary>
/// Application service that provides CRUD operations for specializations
/// </summary>
/// <param name="repository">Repository for specialization entities</param>
/// <param name="mapper">AutoMapper instance used to map between entities and DTOs</param>
public sealed class SpecializationService(IRepository<Specialization, Guid> repository, IMapper mapper)
    : IApplicationService<SpecializationDto, SpecializationCreateUpdateDto, Guid>
{
    /// <inheritdoc />
    public async Task<SpecializationDto> Create(SpecializationCreateUpdateDto dto)
    {
        var entity = mapper.Map<Specialization>(dto);
        var created = await repository.Create(entity);
        return mapper.Map<SpecializationDto>(created);
    }

    /// <inheritdoc />
    public async Task<SpecializationDto?> Get(Guid dtoId)
    {
        var entity = await repository.Read(dtoId);
        return mapper.Map<SpecializationDto>(entity);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<SpecializationDto>> GetAll()
    {
        var entities = await repository.ReadAll();
        return mapper.Map<IReadOnlyList<SpecializationDto>>(entities);
    }

    /// <inheritdoc />
    public async Task<SpecializationDto> Update(SpecializationCreateUpdateDto dto, Guid dtoId)
    {
        var existing = await repository.Read(dtoId) ?? throw new KeyNotFoundException($"Specialization with id {dtoId} not found");
        mapper.Map(dto, existing);
        var updated = await repository.Update(existing);

        return mapper.Map<SpecializationDto>(updated);
    }

    /// <inheritdoc />
    public Task<bool> Delete(Guid dtoId) => repository.Delete(dtoId);
}