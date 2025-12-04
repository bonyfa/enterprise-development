using AutoMapper;
using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Patients;
using Hospital.Application.Contracts.Specializations;
using Hospital.Models;

namespace Hospital.Application;

/// <summary>
/// AutoMapper profile that configures mappings between domain models and application DTOs
/// </summary>
public class HospitalProfile : Profile
{
    public HospitalProfile()
    {
        CreateMap<Appointment, AppointmentDto>();
        CreateMap<AppointmentCreateUpdateDto, Appointment>();

        CreateMap<Doctor, DoctorDto>();
        CreateMap<DoctorCreateUpdateDto, Doctor>();

        CreateMap<Patient, PatientDto>();
        CreateMap<PatientCreateUpdateDto, Patient>();

        CreateMap<Specialization, SpecializationDto>();
        CreateMap<SpecializationCreateUpdateDto, Specialization>();
    }
}