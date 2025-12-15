using Bogus;
using Hospital.Application.Contracts.Appointments;

namespace Hospital.Generator.Kafka.Host.Generator;

/// <summary>
/// Generator for appointment create or update contracts using provided patient and doctor identifier pools
/// </summary>
public static class AppointmentGenerator
{
    /// <summary>
    /// Generates a list of appointment create or update contracts using random data and existing patient and doctor identifiers
    /// </summary>
    /// <param name="count">Number of contracts to generate</param>
    /// <param name="patientIds">Pool of existing patient identifiers</param>
    /// <param name="doctorIds">Pool of existing doctor identifiers</param>
    /// <returns>Generated list of appointment create or update contracts</returns>
    public static List<AppointmentCreateUpdateDto> GenerateContracts(
        int count,
        IList<Guid> patientIds,
        IList<Guid> doctorIds)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(count);
        ArgumentNullException.ThrowIfNull(patientIds);
        ArgumentNullException.ThrowIfNull(doctorIds);
        if (patientIds.Count == 0) throw new ArgumentException("Patient id pool is empty", nameof(patientIds));
        if (doctorIds.Count == 0) throw new ArgumentException("Doctor id pool is empty", nameof(doctorIds));

        var faker = new Faker();

        return new Faker<AppointmentCreateUpdateDto>()
            .CustomInstantiator(_ => new AppointmentCreateUpdateDto(
                DateAndTime: faker.Date.Between(
                    new DateTime(2025, 1, 1, 8, 0, 0),
                    new DateTime(2025, 1, 31, 18, 0, 0)),
                NumberOfOffice: faker.Random.Int(101, 499),
                IsRepeated: faker.Random.Bool(0.35f),
                PatientId: faker.PickRandom(patientIds),
                DoctorId: faker.PickRandom(doctorIds)
            ))
            .Generate(count);
    }
}