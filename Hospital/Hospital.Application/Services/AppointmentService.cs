using AutoMapper;
using Hospital.Application.Contracts.Appointments;
using Hospital.Models;

namespace Hospital.Application.Services;

/// <summary>
/// Application service that provides CRUD operations for appointments and appointment queries by doctor or patient
/// </summary>
/// <param name="appointmentRepository">Repository for appointment entities</param>
/// <param name="doctorRepository">Repository for doctor entities</param>
/// <param name="patientRepository">Repository for patient entities</param>
/// <param name="mapper">AutoMapper instance used to map between entities and DTOs</param>
public sealed class AppointmentService(
    IRepository<Appointment, Guid> appointmentRepository,
    IRepository<Doctor, Guid> doctorRepository,
    IRepository<Patient, Guid> patientRepository,
    IMapper mapper
) : IAppointmentService
{
    /// <inheritdoc />
    public async Task<AppointmentDto> Create(AppointmentCreateUpdateDto dto)
    {
        _ = await doctorRepository.Read(dto.DoctorId) ?? throw new KeyNotFoundException($"Doctor with id {dto.DoctorId} not found");
        _ = await patientRepository.Read(dto.PatientId) ?? throw new KeyNotFoundException($"Patient with id {dto.PatientId} not found");
        var entity = mapper.Map<Appointment>(dto);
        var created = await appointmentRepository.Create(entity);

        return mapper.Map<AppointmentDto>(created);
    }

    /// <inheritdoc />
    public async Task<AppointmentDto?> Get(Guid dtoId)
    {
        var entity = await appointmentRepository.Read(dtoId);
        return mapper.Map<AppointmentDto>(entity);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<AppointmentDto>> GetAll()
    {
        var entities = await appointmentRepository.ReadAll();
        return mapper.Map<IReadOnlyList<AppointmentDto>>(entities);
    }

    /// <inheritdoc />
    public async Task<AppointmentDto> Update(AppointmentCreateUpdateDto dto, Guid dtoId)
    {
        var existing = await appointmentRepository.Read(dtoId) ?? throw new KeyNotFoundException($"Appointment with id {dtoId} not found");
        _ = await doctorRepository.Read(dto.DoctorId) ?? throw new KeyNotFoundException($"Doctor with id {dto.DoctorId} not found");
        _ = await patientRepository.Read(dto.PatientId) ?? throw new KeyNotFoundException($"Patient with id {dto.PatientId} not found");
        mapper.Map(dto, existing);
        var updated = await appointmentRepository.Update(existing);

        return mapper.Map<AppointmentDto>(updated);
    }

    /// <inheritdoc />
    public Task<bool> Delete(Guid dtoId) => appointmentRepository.Delete(dtoId);

    /// <inheritdoc />
    public async Task<IList<AppointmentDto>> GetAppointmentsByDoctorId(Guid doctorId)
    {
        var doctor = await doctorRepository.Read(doctorId) ?? throw new KeyNotFoundException($"Doctor with id {doctorId} not found");
        var appointments = await appointmentRepository.ReadAll();

        return [.. appointments
            .Where(a => a.DoctorId == doctorId)
            .OrderBy(a => a.DateAndTime)
            .Select(mapper.Map<AppointmentDto>)];
    }

    /// <inheritdoc />
    public async Task<IList<AppointmentDto>> GetAppointmentsByPatientId(Guid patientId)
    {
        var patient = await patientRepository.Read(patientId) ?? throw new KeyNotFoundException($"Patient with id {patientId} not found");
        var appointments = await appointmentRepository.ReadAll();

        return [.. appointments
            .Where(a => a.PatientId == patientId)
            .OrderBy(a => a.DateAndTime)
            .Select(mapper.Map<AppointmentDto>)];
    }
}