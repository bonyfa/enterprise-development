using Bogus;
using Hospital.Application.Contracts.Appointments;

namespace Hospital.Generator.Kafka.Host.Generator;

/// <summary>
/// Generates random appointment contracts to emulate an external system sending data
/// </summary>
public static class AppointmentGenerator
{
    /// <summary>
    /// Generates a list of appointment create or update contracts
    /// </summary>
    /// <param name="count">Number of contracts to generate</param>
    /// <param name="patientIds">Pool of existing patient identifiers</param>
    /// <param name="doctorIds">Pool of existing doctor identifiers</param>
    /// <returns>Generated list of appointment contracts</returns>
    public static List<AppointmentCreateUpdateDto> GenerateContracts(int count,IList<Guid> patientIds, IList<Guid> doctorIds) => 
        new Faker<AppointmentCreateUpdateDto>()
            .CustomInstantiator(f => new AppointmentCreateUpdateDto(
                DateAndTime: f.Date.Between(DateTime.UtcNow.AddDays(-30), DateTime.UtcNow.AddDays(30)),
                NumberOfOffice: f.Random.Int(100, 499),
                IsRepeated: f.Random.Bool(),
                PatientId: f.PickRandom(patientIds),
                DoctorId: f.PickRandom(doctorIds)
            ))
            .Generate(count);
}