using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.EfCore.Repositories;

/// <summary>
/// Repository implementation for the Specialization entity
/// </summary>
public class SpecializationRepository(HospitalDbContext context) : IRepository<Specialization, Guid>
{
    /// <summary>
    /// Creates a new specialization entity in the database
    /// </summary>
    /// <param name="entity">The specialization to create</param>
    /// <returns>The created specialization entity</returns>
    public async Task<Specialization> Create(Specialization entity)
    {
        var result = await context.Specializations.AddAsync(entity);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Deletes a specialization entity by its identifier
    /// </summary>
    /// <param name="entityId">The unique ID of the specialization</param>
    /// <returns>True if the deletion was successful, otherwise false</returns>
    public async Task<bool> Delete(Guid entityId)
    {
        var entity = await context.Specializations.FirstOrDefaultAsync(e => e.Id == entityId);

        if (entity == null)
            return false;

        context.Specializations.Remove(entity);

        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Retrieves a specific specialization by its identifier
    /// </summary>
    /// <param name="entityId">The unique ID of the specialization</param>
    /// <returns>The specialization entity, or null if not found</returns>
    public async Task<Specialization?> Read(Guid entityId)
    {
        return await context.Specializations.FirstOrDefaultAsync(e => e.Id == entityId);
    }

    /// <summary>
    /// Retrieves all specialization entities from the database
    /// </summary>
    /// <returns>A read-only list of all specializations</returns>
    public async Task<IReadOnlyList<Specialization>> ReadAll()
    {
        return await context.Specializations.ToListAsync();
    }

    /// <summary>
    /// Updates an existing specialization entity
    /// </summary>
    /// <param name="entity">The modified specialization entity</param>
    /// <returns>The updated specialization entity</returns>
    public async Task<Specialization> Update(Specialization entity)
    {
        context.Specializations.Update(entity);

        await context.SaveChangesAsync();

        return entity;
    }
}