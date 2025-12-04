using Hospital.Application.Contracts.Specializations;

namespace Hospital.Application.Contracts.Doctors;

/// <summary>
/// Application service for managing doctors and related doctor queries
/// </summary>
public interface IDoctorService : IApplicationService<DoctorDto, DoctorCreateUpdateDto, Guid>
{
    /// <summary>
    /// Returns doctor specialization by doctor identifier
    /// </summary>
    /// <param name="doctorId">Doctor identifier</param>
    /// <returns>Specialization DTO for the specified doctor</returns>
    public Task<SpecializationDto> GetSpecialization(Guid doctorId);
}