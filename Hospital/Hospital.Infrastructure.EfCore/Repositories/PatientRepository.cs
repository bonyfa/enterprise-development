using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.EfCore.Repositories;

/// <summary>
/// Repository implementation for the Patient entity
/// </summary>
public class PatientRepository(HospitalDbContext context) : IRepository<Patient, Guid>
{
    /// <summary>
    /// Creates a new patient entity in the database
    /// </summary>
    /// <param name="entity">The patient to create</param>
    /// <returns>The created patient entity</returns>
    public async Task<Patient> Create(Patient entity)
    {
        var result = await context.Patients.AddAsync(entity);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Deletes a patient entity by its identifier
    /// </summary>
    /// <param name="entityId">The unique ID of the patient</param>
    /// <returns>True if the deletion was successful, otherwise false</returns>
    public async Task<bool> Delete(Guid entityId)
    {
        var entity = await context.Patients.FirstOrDefaultAsync(e => e.Id == entityId);

        if (entity == null)
            return false;

        context.Patients.Remove(entity);

        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Retrieves a specific patient by its identifier
    /// </summary>
    /// <param name="entityId">The unique ID of the patient</param>
    /// <returns>The patient entity, or null if not found</returns>
    public async Task<Patient?> Read(Guid entityId)
    {
        return await context.Patients.FirstOrDefaultAsync(e => e.Id == entityId);
    }

    /// <summary>
    /// Retrieves all patient entities from the database
    /// </summary>
    /// <returns>A read-only list of all patients</returns>
    public async Task<IReadOnlyList<Patient>> ReadAll()
    {
        return await context.Patients.ToListAsync();
    }

    /// <summary>
    /// Updates an existing patient entity
    /// </summary>
    /// <param name="entity">The modified patient entity</param>
    /// <returns>The updated patient entity</returns>
    public async Task<Patient> Update(Patient entity)
    {
        context.Patients.Update(entity);

        await context.SaveChangesAsync();

        return entity;
    }
}