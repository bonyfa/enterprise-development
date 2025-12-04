using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.EfCore.Repositories;

/// <summary>
/// Repository implementation for the Doctor entity
/// </summary>
public class DoctorRepository(HospitalDbContext context) : IRepository<Doctor, Guid>
{
    /// <summary>
    /// Creates a new doctor entity in the database
    /// </summary>
    /// <param name="entity">The doctor to create</param>
    /// <returns>The created doctor entity</returns>
    public async Task<Doctor> Create(Doctor entity)
    {
        var result = await context.Doctors.AddAsync(entity);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Deletes a doctor entity by its identifier
    /// </summary>
    /// <param name="entityId">The unique ID of the doctor</param>
    /// <returns>True if the deletion was successful, otherwise false</returns>
    public async Task<bool> Delete(Guid entityId)
    {
        var entity = await context.Doctors.FirstOrDefaultAsync(e => e.Id == entityId);

        if (entity == null)
            return false;

        context.Doctors.Remove(entity);

        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Retrieves a specific doctor by its identifier
    /// </summary>
    /// <param name="entityId">The unique ID of the doctor</param>
    /// <returns>The doctor entity, or null if not found</returns>
    public async Task<Doctor?> Read(Guid entityId)
    {
        return await context.Doctors.FirstOrDefaultAsync(e => e.Id == entityId);
    }

    /// <summary>
    /// Retrieves all doctor entities from the database
    /// </summary>
    /// <returns>A read-only list of all doctors</returns>
    public async Task<IReadOnlyList<Doctor>> ReadAll()
    {
        return await context.Doctors.ToListAsync();
    }

    /// <summary>
    /// Updates an existing doctor entity
    /// </summary>
    /// <param name="entity">The modified doctor entity</param>
    /// <returns>The updated doctor entity</returns>
    public async Task<Doctor> Update(Doctor entity)
    {
        context.Doctors.Update(entity);

        await context.SaveChangesAsync();

        return entity;
    }
}