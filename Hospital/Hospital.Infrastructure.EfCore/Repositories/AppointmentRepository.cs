using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.EfCore.Repositories;

/// <summary>
/// Repository implementation for the Appointment entity
/// </summary>
public class AppointmentRepository(HospitalDbContext context) : IRepository<Appointment, Guid>
{
    /// <summary>
    /// Creates a new appointment entity in the database
    /// </summary>
    /// <param name="entity">The appointment to create</param>
    /// <returns>The created appointment entity</returns>
    public async Task<Appointment> Create(Appointment entity)
    {
        var result = await context.Appointments.AddAsync(entity);

        await context.SaveChangesAsync();

        return result.Entity;
    }

    /// <summary>
    /// Deletes an appointment entity by its identifier
    /// </summary>
    /// <param name="entityId">The unique ID of the appointment</param>
    /// <returns>True if the deletion was successful, otherwise false</returns>
    public async Task<bool> Delete(Guid entityId)
    {
        var entity = await context.Appointments.FirstOrDefaultAsync(e => e.Id == entityId);

        if (entity == null)
            return false;

        context.Appointments.Remove(entity);

        await context.SaveChangesAsync();

        return true;
    }

    /// <summary>
    /// Retrieves a specific appointment by its identifier
    /// </summary>
    /// <param name="entityId">The unique ID of the appointment</param>
    /// <returns>The appointment entity, or null if not found</returns>
    public async Task<Appointment?> Read(Guid entityId)
    {
        return await context.Appointments.FirstOrDefaultAsync(e => e.Id == entityId);
    }

    /// <summary>
    /// Retrieves all appointment entities from the database
    /// </summary>
    /// <returns>A read-only list of all appointments</returns>
    public async Task<IReadOnlyList<Appointment>> ReadAll()
    {
        return await context.Appointments.ToListAsync();
    }

    /// <summary>
    /// Updates an existing appointment entity
    /// </summary>
    /// <param name="entity">The modified appointment entity</param>
    /// <returns>The updated appointment entity</returns>
    public async Task<Appointment> Update(Appointment entity)
    {
        context.Appointments.Update(entity);

        await context.SaveChangesAsync();

        return entity;
    }
}