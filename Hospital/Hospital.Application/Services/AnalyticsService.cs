using AutoMapper;
using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Patients;
using Hospital.Models;

namespace Hospital.Application.Services;

/// <summary>
/// Application service that provides analytical queries over hospital data
/// </summary>
/// <param name="appointmentRepository">Repository for appointment entities</param>
/// <param name="doctorRepository">Repository for doctor entities</param>
/// <param name="patientRepository">Repository for patient entities</param>
/// <param name="mapper">AutoMapper instance used to map between entities and DTOs</param>
public sealed class AnalyticsService(
    IRepository<Appointment, Guid> appointmentRepository,
    IRepository<Doctor, Guid> doctorRepository,
    IRepository<Patient, Guid> patientRepository,
    IMapper mapper
) : IAnalyticsService
{
    /// <inheritdoc />
    public async Task<IReadOnlyList<DoctorDto>> GetDoctorsByMinWorkExperienceAsync(int minYears)
    {
        var doctors = await doctorRepository.ReadAll();

        return [.. doctors
            .Where(d => d.WorkExperience >= minYears)
            .OrderBy(d => d.PassportId)
            .Select(mapper.Map<DoctorDto>)];
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<PatientDto>> GetPatientsByDoctorIdOrderedByFullName(Guid doctorId)
    {
        _ = await doctorRepository.Read(doctorId) ?? throw new KeyNotFoundException($"Doctor with id {doctorId} not found");

        var appointments = await appointmentRepository.ReadAll();
        var patientIds = appointments
            .Where(a => a.DoctorId == doctorId)
            .Select(a => a.PatientId)
            .Distinct()
            .ToHashSet();

        if (patientIds.Count == 0)
            return [];

        var patients = await patientRepository.ReadAll();

        return [.. patients
            .Where(p => patientIds.Contains(p.Id))
            .OrderBy(p => p.FullName)
            .Select(mapper.Map<PatientDto>)];
    }

    /// <inheritdoc />
    public async Task<int> GetRepeatedAppointmentsCount(DateTime from, DateTime to)
    {
        var appointments = await appointmentRepository.ReadAll();

        return appointments.Count(a =>
            a.IsRepeated &&
            a.DateAndTime >= from &&
            a.DateAndTime <= to);
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<PatientDto>> GetPatientsOverAgeWithMultipleDoctorsAsync(DateOnly today, int minAgeYears)
    {
        var ageLimit = today.AddYears(-minAgeYears);

        var patients = await patientRepository.ReadAll();

        var eligiblePatients = patients
            .Where(p => p.DateOfBirth <= ageLimit)
            .ToList();

        if (eligiblePatients.Count == 0)
            return [];

        var eligibleIds = eligiblePatients.Select(p => p.Id).ToHashSet();

        var appointments = await appointmentRepository.ReadAll();

        var multiDoctorPatientIds = appointments
            .Where(a => eligibleIds.Contains(a.PatientId))
            .GroupBy(a => a.PatientId)
            .Where(g => g.Select(a => a.DoctorId).Distinct().Count() > 1)
            .Select(g => g.Key)
            .ToHashSet();

        if (multiDoctorPatientIds.Count == 0)
            return [];

        return [.. eligiblePatients
            .Where(p => multiDoctorPatientIds.Contains(p.Id))
            .OrderBy(p => p.DateOfBirth)
            .Select(mapper.Map<PatientDto>)];
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<AppointmentDto>> GetAppointmentsByOfficeInMonthAsync(int officeNumber, int year, int month)
    {
        var appointments = await appointmentRepository.ReadAll();

        return [.. appointments
            .Where(a => a.NumberOfOffice == officeNumber &&
                        a.DateAndTime.Year == year &&
                        a.DateAndTime.Month == month)
            .OrderBy(a => a.DateAndTime)
            .Select(mapper.Map<AppointmentDto>)];
    }
}