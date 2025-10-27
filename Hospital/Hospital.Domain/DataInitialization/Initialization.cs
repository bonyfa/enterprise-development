using Hospital.Enums;
using Hospital.Models;

namespace Hospital.DataInitialization;

//<summary>
//Model for Initialization Data
//</summary>
public static class Initialization
{
    //<summary>
    //Generate data list for Specializations
    //</summary>
    public static List<Specialization> Specializations => new List<Specialization>
    {
        new Specialization { Id = 1, Name = "Терапевт" },
        new Specialization { Id = 2, Name = "Хирург" },
        new Specialization { Id = 3, Name = "Дерматовенеролог" },
        new Specialization { Id = 4, Name = "Офтальмолог" },
        new Specialization { Id = 5, Name = "Уролог" },
        new Specialization { Id = 6, Name = "Гинеколог" },
        new Specialization { Id = 7, Name = "Рентгенолог" },
        new Specialization { Id = 8, Name = "Анестезиолог" },
        new Specialization { Id = 9, Name = "Вирусолог" },
        new Specialization { Id = 10, Name = "Ортопед" }
    };
    
    //<summary>
    //Generate data list for Specializations
    //</summary>
   public static List<Patient> Patients => new List<Patient>
{
    new Patient
    { 
        PassportId = 45123456, 
        FullName = "Иванов Иван Иванович", 
        Gender = Gender.Male, 
        DateOfBirth = new DateTime(1985, 3, 15), 
        Address = "г. Москва, ул. Ленина, д. 10, кв. 25", 
        BloodGroup = BloodGroup.A, 
        RhesusFactor = RhesusFactor.Positive, 
        PhoneNumber = "+7 (495) 123-45-67" 
    },
    new Patient
    { 
        PassportId = 45987654, 
        FullName = "Петрова Анна Сергеевна", 
        Gender = Gender.Female, 
        DateOfBirth = new DateTime(1990, 7, 22), 
        Address = "г. Санкт-Петербург, Невский пр-т, д. 45, кв. 12", 
        BloodGroup = BloodGroup.B, 
        RhesusFactor = RhesusFactor.Negative, 
        PhoneNumber = "+7 (812) 234-56-78" 
    },
    new Patient
    { 
        PassportId = 45567890, 
        FullName = "Сидоров Алексей Петрович", 
        Gender = Gender.Male, 
        DateOfBirth = new DateTime(1978, 11, 5), 
        Address = "г. Екатеринбург, ул. Мира, д. 33, кв. 8", 
        BloodGroup = BloodGroup.O, 
        RhesusFactor = RhesusFactor.Positive, 
        PhoneNumber = "+7 (343) 345-67-89" 
    },
    new Patient
    { 
        PassportId = 45345678, 
        FullName = "Козлова Мария Владимировна", 
        Gender = Gender.Female, 
        DateOfBirth = new DateTime(1995, 1, 30), 
        Address = "г. Новосибирск, ул. Кирова, д. 78, кв. 15", 
        BloodGroup = BloodGroup.Ab, 
        RhesusFactor = RhesusFactor.Positive, 
        PhoneNumber = "+7 (383) 456-78-90" 
    },
    new Patient
    { 
        PassportId = 45789012, 
        FullName = "Федоров Дмитрий Николаевич", 
        Gender = Gender.Male, 
        DateOfBirth = new DateTime(1982, 8, 14), 
        Address = "г. Казань, ул. Баумана, д. 25, кв. 7", 
        BloodGroup = BloodGroup.A, 
        RhesusFactor = RhesusFactor.Negative, 
        PhoneNumber = "+7 (843) 567-89-01" 
    },
    new Patient
    { 
        PassportId = 45456789, 
        FullName = "Николаева Ольга Игоревна", 
        Gender = Gender.Female, 
        DateOfBirth = new DateTime(1988, 12, 3), 
        Address = "г. Ростов-на-Дону, ул. Пушкинская, д. 60, кв. 33", 
        BloodGroup = BloodGroup.B, 
        RhesusFactor = RhesusFactor.Positive, 
        PhoneNumber = "+7 (863) 678-90-12" 
    },
    new Patient
    { 
        PassportId = 45678901, 
        FullName = "Волков Сергей Александрович", 
        Gender = Gender.Male, 
        DateOfBirth = new DateTime(1975, 5, 18), 
        Address = "г. Челябинск, ул. Комарова, д. 12, кв. 9", 
        BloodGroup = BloodGroup.O, 
        RhesusFactor = RhesusFactor.Negative, 
        PhoneNumber = "+7 (351) 789-01-23" 
    },
    new Patient
    { 
        PassportId = 45234567, 
        FullName = "Смирнова Екатерина Дмитриевна", 
        Gender = Gender.Female, 
        DateOfBirth = new DateTime(1992, 9, 25), 
        Address = "г. Уфа, ул. Революционная, д. 88, кв. 21", 
        BloodGroup = BloodGroup.Ab, 
        RhesusFactor = RhesusFactor.Negative, 
        PhoneNumber = "+7 (347) 890-12-34" 
    },
    new Patient
    { 
        PassportId = 45890123, 
        FullName = "Попов Андрей Викторович", 
        Gender = Gender.Male, 
        DateOfBirth = new DateTime(1980, 4, 8), 
        Address = "г. Волгоград, ул. Рабоче-Крестьянская, д. 15, кв. 44", 
        BloodGroup = BloodGroup.A, 
        RhesusFactor = RhesusFactor.Positive, 
        PhoneNumber = "+7 (844) 901-23-45" 
    },
    new Patient
    { 
        PassportId = 45561234, 
        FullName = "Лебедева Татьяна Павловна", 
        Gender = Gender.Female, 
        DateOfBirth = new DateTime(1987, 6, 11), 
        Address = "г. Пермь, ул. Ленина, д. 95, кв. 16", 
        BloodGroup = BloodGroup.B, 
        RhesusFactor = RhesusFactor.Positive, 
        PhoneNumber = "+7 (342) 012-34-56" 
    }
};

    //<summary>
    //Generate data list for Doctors
    //</summary>
    public static List<Doctor> Doctors => new List<Doctor>
    {
    new Doctor 
    { 
        PassportId = 45112233, 
        FullName = "Смирнов Александр Иванович", 
        DateOfBirth = new DateTime(1975, 5, 15), 
        Specialization = Specializations[0], 
        WorkExperience = 20
    },
    new Doctor 
    { 
        PassportId = 45445566, 
        FullName = "Петрова Елена Викторовна", 
        DateOfBirth = new DateTime(1980, 8, 22), 
        Specialization = Specializations[1], 
        WorkExperience = 15 
    },
    new Doctor 
    { 
        PassportId = 45778899, 
        FullName = "Козлов Дмитрий Сергеевич", 
        DateOfBirth = new DateTime(1978, 3, 10), 
        Specialization = Specializations[2], 
        WorkExperience = 18 
    },
    new Doctor 
    { 
        PassportId = 45123450, 
        FullName = "Иванова Ольга Николаевна", 
        DateOfBirth = new DateTime(1985, 11, 5), 
        Specialization = Specializations[3], 
        WorkExperience = 12 
    },
    new Doctor 
    { 
        PassportId = 45234561, 
        FullName = "Федоров Максим Андреевич", 
        DateOfBirth = new DateTime(1970, 7, 30), 
        Specialization = Specializations[4], 
        WorkExperience = 25 
    },
    new Doctor 
    { 
        PassportId = 45345672, 
        FullName = "Николаева Светлана Петровна", 
        DateOfBirth = new DateTime(1982, 1, 18), 
        Specialization = Specializations[5], 
        WorkExperience = 13 
    },
    new Doctor 
    { 
        PassportId = 45456783, 
        FullName = "Волков Артем Игоревич", 
        DateOfBirth = new DateTime(1973, 9, 8), 
        Specialization = Specializations[6], 
        WorkExperience = 22 
    },
    new Doctor 
    { 
        PassportId = 45567894, 
        FullName = "Семенова Анна Дмитриевна", 
        DateOfBirth = new DateTime(1988, 4, 25), 
        Specialization = Specializations[7], 
        WorkExperience = 9 
    },
    new Doctor 
    { 
        PassportId = 45678905, 
        FullName = "Павлов Сергей Владимирович", 
        DateOfBirth = new DateTime(1976, 12, 12), 
        Specialization = Specializations[8], 
        WorkExperience = 19 
    },
    new Doctor 
    { 
        PassportId = 45789016, 
        FullName = "Морозова Ирина Александровна", 
        DateOfBirth = new DateTime(1983, 6, 7), 
        Specialization = Specializations[9], 
        WorkExperience = 14 
    }
};
    
    //<summary>
    //Generate data list for Appointment
    //</summary>
    public static List<Appointment> Appointments => new List<Appointment>
{
    new Appointment
    {
        Id = 1,
        DateAndTime = new DateTime(2025, 1, 15, 9, 0, 0),
        NumberOfOffice = 101,
        IsRepeated = false,
        Patient = Patients[0],
        Doctor = Doctors[0]
    },
    new Appointment
    {
        Id = 2,
        DateAndTime = new DateTime(2025, 1, 15, 10, 30, 0),
        NumberOfOffice = 205,
        IsRepeated = true,
        Patient = Patients[1],
        Doctor = Doctors[1]
    },
    new Appointment
    {
        Id = 3,
        DateAndTime = new DateTime(2025, 1, 16, 11, 0, 0),
        NumberOfOffice = 312,
        IsRepeated = false,
        Patient = Patients[2],
        Doctor = Doctors[2]
    },
    new Appointment
    {
        Id = 4,
        DateAndTime = new DateTime(2025, 1, 16, 14, 15, 0),
        NumberOfOffice = 118,
        IsRepeated = true,
        Patient = Patients[3],
        Doctor = Doctors[3]
    },
    new Appointment
    {
        Id = 5,
        DateAndTime = new DateTime(2025, 1, 17, 8, 45, 0),
        NumberOfOffice = 224,
        IsRepeated = false,
        Patient = Patients[4],
        Doctor = Doctors[4]
    },
    new Appointment
    {
        Id = 6,
        DateAndTime = new DateTime(2025, 1, 17, 13, 20, 0),
        NumberOfOffice = 307,
        IsRepeated = true,
        Patient = Patients[5],
        Doctor = Doctors[5]
    },
    new Appointment
    {
        Id = 7,
        DateAndTime = new DateTime(2025, 1, 18, 10, 0, 0),
        NumberOfOffice = 201,
        IsRepeated = false,
        Patient = Patients[6],
        Doctor = Doctors[6]
    },
    new Appointment
    {
        Id = 8,
        DateAndTime = new DateTime(2025, 1, 18, 15, 30, 0),
        NumberOfOffice = 415,
        IsRepeated = true,
        Patient = Patients[7],
        Doctor = Doctors[7]
    },
    new Appointment
    {
        Id = 9,
        DateAndTime = new DateTime(2025, 1, 19, 9, 30, 0),
        NumberOfOffice = 108,
        IsRepeated = false,
        Patient = Patients[8],
        Doctor = Doctors[8]
    },
    new Appointment
    {
        Id = 10,
        DateAndTime = new DateTime(2025, 1, 19, 16, 0, 0),
        NumberOfOffice = 303,
        IsRepeated = true,
        Patient = Patients[9],
        Doctor = Doctors[9]
    }
};
}