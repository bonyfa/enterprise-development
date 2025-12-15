using Hospital.Domain.Shared.Enums;
using Hospital.Models;

namespace Hospital.DataInitialization;

/// <summary>
/// Model for Initialization Data
/// </summary>
public static class Initialization
{
    /// <summary>
    /// Generate data list for Specializations
    /// </summary>
    public static readonly List<Specialization> Specializations =
    [
        new Specialization { Id = Guid.Parse("11111111-1111-1111-1111-111111111101"), Name = "Терапевт" },
        new Specialization { Id = Guid.Parse("11111111-1111-1111-1111-111111111102"), Name = "Хирург" },
        new Specialization { Id = Guid.Parse("11111111-1111-1111-1111-111111111103"), Name = "Дерматовенеролог" },
        new Specialization { Id = Guid.Parse("11111111-1111-1111-1111-111111111104"), Name = "Офтальмолог" },
        new Specialization { Id = Guid.Parse("11111111-1111-1111-1111-111111111105"), Name = "Уролог" },
        new Specialization { Id = Guid.Parse("11111111-1111-1111-1111-111111111106"), Name = "Гинеколог" },
        new Specialization { Id = Guid.Parse("11111111-1111-1111-1111-111111111107"), Name = "Рентгенолог" },
        new Specialization { Id = Guid.Parse("11111111-1111-1111-1111-111111111108"), Name = "Анестезиолог" },
        new Specialization { Id = Guid.Parse("11111111-1111-1111-1111-111111111109"), Name = "Вирусолог" },
        new Specialization { Id = Guid.Parse("11111111-1111-1111-1111-111111111110"), Name = "Ортопед" }
    ];

    /// <summary>
    /// Generate data list for Patients
    /// </summary>
    public static readonly List<Patient> Patients =
    [
        new Patient
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222201"),
            PassportId = 45123456,
            FullName = "Иванов Иван Иванович",
            Gender = Gender.Male,
            DateOfBirth = new DateOnly(1985, 3, 15),
            Address = "г. Москва, ул. Ленина, д. 10, кв. 25",
            BloodGroup = BloodGroup.A,
            RhesusFactor = RhesusFactor.Positive,
            PhoneNumber = "+7 (495) 123-45-67"
        },
        new Patient
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222202"),
            PassportId = 45987654,
            FullName = "Петрова Анна Сергеевна",
            Gender = Gender.Female,
            DateOfBirth = new DateOnly(1990, 7, 22),
            Address = "г. Санкт-Петербург, Невский пр-т, д. 45, кв. 12",
            BloodGroup = BloodGroup.B,
            RhesusFactor = RhesusFactor.Negative,
            PhoneNumber = "+7 (812) 234-56-78"
        },
        new Patient
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222203"),
            PassportId = 45567890,
            FullName = "Сидоров Алексей Петрович",
            Gender = Gender.Male,
            DateOfBirth = new DateOnly(1978, 11, 5),
            Address = "г. Екатеринбург, ул. Мира, д. 33, кв. 8",
            BloodGroup = BloodGroup.O,
            RhesusFactor = RhesusFactor.Positive,
            PhoneNumber = "+7 (343) 345-67-89"
        },
        new Patient
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222204"),
            PassportId = 45345678,
            FullName = "Козлова Мария Владимировна",
            Gender = Gender.Female,
            DateOfBirth = new DateOnly(1995, 1, 30),
            Address = "г. Новосибирск, ул. Кирова, д. 78, кв. 15",
            BloodGroup = BloodGroup.AB,
            RhesusFactor = RhesusFactor.Positive,
            PhoneNumber = "+7 (383) 456-78-90"
        },
        new Patient
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222205"),
            PassportId = 45789012,
            FullName = "Федоров Дмитрий Николаевич",
            Gender = Gender.Male,
            DateOfBirth = new DateOnly(1982, 8, 14),
            Address = "г. Казань, ул. Баумана, д. 25, кв. 7",
            BloodGroup = BloodGroup.A,
            RhesusFactor = RhesusFactor.Negative,
            PhoneNumber = "+7 (843) 567-89-01"
        },
        new Patient
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222206"),
            PassportId = 45456789,
            FullName = "Николаева Ольга Игоревна",
            Gender = Gender.Female,
            DateOfBirth = new DateOnly(1988, 12, 3),
            Address = "г. Ростов-на-Дону, ул. Пушкинская, д. 60, кв. 33",
            BloodGroup = BloodGroup.B,
            RhesusFactor = RhesusFactor.Positive,
            PhoneNumber = "+7 (863) 678-90-12"
        },
        new Patient
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222207"),
            PassportId = 45678901,
            FullName = "Волков Сергей Александрович",
            Gender = Gender.Male,
            DateOfBirth = new DateOnly(1975, 5, 18),
            Address = "г. Челябинск, ул. Комарова, д. 12, кв. 9",
            BloodGroup = BloodGroup.O,
            RhesusFactor = RhesusFactor.Negative,
            PhoneNumber = "+7 (351) 789-01-23"
        },
        new Patient
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222208"),
            PassportId = 45234567,
            FullName = "Смирнова Екатерина Дмитриевна",
            Gender = Gender.Female,
            DateOfBirth = new DateOnly(1992, 9, 25),
            Address = "г. Уфа, ул. Революционная, д. 88, кв. 21",
            BloodGroup = BloodGroup.AB,
            RhesusFactor = RhesusFactor.Negative,
            PhoneNumber = "+7 (347) 890-12-34"
        },
        new Patient
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222209"),
            PassportId = 45890123,
            FullName = "Попов Андрей Викторович",
            Gender = Gender.Male,
            DateOfBirth = new DateOnly(1980, 4, 8),
            Address = "г. Волгоград, ул. Рабоче-Крестьянская, д. 15, кв. 44",
            BloodGroup = BloodGroup.A,
            RhesusFactor = RhesusFactor.Positive,
            PhoneNumber = "+7 (844) 901-23-45"
        },
        new Patient
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222210"),
            PassportId = 45561234,
            FullName = "Лебедева Татьяна Павловна",
            Gender = Gender.Female,
            DateOfBirth = new DateOnly(1987, 6, 11),
            Address = "г. Пермь, ул. Ленина, д. 95, кв. 16",
            BloodGroup = BloodGroup.B,
            RhesusFactor = RhesusFactor.Positive,
            PhoneNumber = "+7 (342) 012-34-56"
        }
    ];

    /// <summary>
    /// Generate data list for Doctors
    /// </summary>
    public static readonly List<Doctor> Doctors =
    [
        new Doctor
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333301"),
            PassportId = 45112233,
            FullName = "Смирнов Александр Иванович",
            DateOfBirth = new DateOnly(1975, 5, 15),
            SpecializationId = Specializations[0].Id,
            WorkExperience = 20
        },
        new Doctor
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333302"),
            PassportId = 45445566,
            FullName = "Петрова Елена Викторовна",
            DateOfBirth = new DateOnly(1980, 8, 22),
            SpecializationId = Specializations[1].Id,
            WorkExperience = 15
        },
        new Doctor
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333303"),
            PassportId = 45778899,
            FullName = "Козлов Дмитрий Сергеевич",
            DateOfBirth = new DateOnly(1978, 3, 10),
            SpecializationId = Specializations[2].Id,
            WorkExperience = 18
        },
        new Doctor
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333304"),
            PassportId = 45123450,
            FullName = "Иванова Ольга Николаевна",
            DateOfBirth = new DateOnly(1985, 11, 5),
            SpecializationId = Specializations[3].Id,
            WorkExperience = 12
        },
        new Doctor
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333305"),
            PassportId = 45234561,
            FullName = "Федоров Максим Андреевич",
            DateOfBirth = new DateOnly(1970, 7, 30),
            SpecializationId = Specializations[4].Id,
            WorkExperience = 25
        },
        new Doctor
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333306"),
            PassportId = 45345672,
            FullName = "Николаева Светлана Петровна",
            DateOfBirth = new DateOnly(1982, 1, 18),
            SpecializationId = Specializations[5].Id,
            WorkExperience = 13
        },
        new Doctor
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333307"),
            PassportId = 45456783,
            FullName = "Волков Артем Игоревич",
            DateOfBirth = new DateOnly(1973, 9, 8),
            SpecializationId = Specializations[6].Id,
            WorkExperience = 22
        },
        new Doctor
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333308"),
            PassportId = 45567894,
            FullName = "Семенова Анна Дмитриевна",
            DateOfBirth = new DateOnly(1988, 4, 25),
            SpecializationId = Specializations[7].Id,
            WorkExperience = 9
        },
        new Doctor
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333309"),
            PassportId = 45678905,
            FullName = "Павлов Сергей Владимирович",
            DateOfBirth = new DateOnly(1976, 12, 12),
            SpecializationId = Specializations[8].Id,
            WorkExperience = 19
        },
        new Doctor
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333310"),
            PassportId = 45789016,
            FullName = "Морозова Ирина Александровна",
            DateOfBirth = new DateOnly(1983, 6, 7),
            SpecializationId = Specializations[9].Id,
            WorkExperience = 14
        }
    ];

    /// <summary>
    /// Generate data list for Appointment
    /// </summary>
    public static readonly List<Appointment> Appointments =
    [
        new Appointment
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444401"),
            DateAndTime = new DateTime(2025, 1, 15, 9, 0, 0),
            NumberOfOffice = 101,
            IsRepeated = false,
            PatientId = Patients[0].Id,
            DoctorId = Doctors[0].Id
        },
        new Appointment
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444402"),
            DateAndTime = new DateTime(2025, 1, 15, 10, 30, 0),
            NumberOfOffice = 205,
            IsRepeated = true,
            PatientId = Patients[1].Id,
            DoctorId = Doctors[1].Id
        },
        new Appointment
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444403"),
            DateAndTime = new DateTime(2025, 1, 16, 11, 0, 0),
            NumberOfOffice = 312,
            IsRepeated = false,
            PatientId = Patients[2].Id,
            DoctorId = Doctors[2].Id
        },
        new Appointment
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444404"),
            DateAndTime = new DateTime(2025, 1, 16, 14, 15, 0),
            NumberOfOffice = 118,
            IsRepeated = true,
            PatientId = Patients[3].Id,
            DoctorId = Doctors[3].Id
        },
        new Appointment
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444405"),
            DateAndTime = new DateTime(2025, 1, 17, 8, 45, 0),
            NumberOfOffice = 224,
            IsRepeated = false,
            PatientId = Patients[4].Id,
            DoctorId = Doctors[4].Id
        },
        new Appointment
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444406"),
            DateAndTime = new DateTime(2025, 1, 17, 13, 20, 0),
            NumberOfOffice = 307,
            IsRepeated = true,
            PatientId = Patients[5].Id,
            DoctorId = Doctors[5].Id
        },
        new Appointment
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444407"),
            DateAndTime = new DateTime(2025, 1, 18, 10, 0, 0),
            NumberOfOffice = 201,
            IsRepeated = false,
            PatientId = Patients[6].Id,
            DoctorId = Doctors[6].Id
        },
        new Appointment
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444408"),
            DateAndTime = new DateTime(2025, 1, 18, 15, 30, 0),
            NumberOfOffice = 415,
            IsRepeated = true,
            PatientId = Patients[7].Id,
            DoctorId = Doctors[7].Id
        },
        new Appointment
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444409"),
            DateAndTime = new DateTime(2025, 1, 19, 9, 30, 0),
            NumberOfOffice = 108,
            IsRepeated = false,
            PatientId = Patients[8].Id,
            DoctorId = Doctors[8].Id
        },
        new Appointment
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444410"),
            DateAndTime = new DateTime(2025, 1, 19, 16, 0, 0),
            NumberOfOffice = 303,
            IsRepeated = true,
            PatientId = Patients[9].Id,
            DoctorId = Doctors[9].Id
        },
        new Appointment
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444411"),
            DateAndTime = new DateTime(2025, 1, 20, 11, 0, 0),
            NumberOfOffice = 101,
            IsRepeated = false,
            PatientId = Patients[0].Id,
            DoctorId = Doctors[1].Id
        },
        new Appointment
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444412"),
            DateAndTime = new DateTime(2025, 1, 21, 14, 0, 0),
            NumberOfOffice = 205,
            IsRepeated = true,
            PatientId = Patients[2].Id,
            DoctorId = Doctors[0].Id
        },
        new Appointment
        {
            Id = Guid.Parse("44444444-4444-4444-4444-444444444413"),
            DateAndTime = new DateTime(2025, 1, 22, 10, 0, 0),
            NumberOfOffice = 312,
            IsRepeated = false,
            PatientId = Patients[4].Id,
            DoctorId = Doctors[8].Id
        }
    ];
}    