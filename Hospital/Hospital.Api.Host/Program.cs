using Hospital;
using Hospital.Application;
using Hospital.Application.Contracts;
using Hospital.Application.Contracts.Appointments;
using Hospital.Application.Contracts.Doctors;
using Hospital.Application.Contracts.Patients;
using Hospital.Application.Contracts.Specializations;
using Hospital.Application.Services;
using Hospital.DataInitialization;
using Hospital.Infrastructure.EfCore;
using Hospital.Infrastructure.EfCore.Repositories;
using Hospital.Infrastructure.Kafka;
using Hospital.Infrastructure.Kafka.Deserializers;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddTransient<IRepository<Appointment, Guid>, AppointmentRepository>();
builder.Services.AddTransient<IRepository<Doctor, Guid>, DoctorRepository>();
builder.Services.AddTransient<IRepository<Patient, Guid>, PatientRepository>();
builder.Services.AddTransient<IRepository<Specialization, Guid>, SpecializationRepository>();

builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IApplicationService<PatientDto, PatientCreateUpdateDto, Guid>, PatientService>();
builder.Services.AddScoped<IApplicationService<SpecializationDto, SpecializationCreateUpdateDto, Guid>, SpecializationService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new HospitalProfile());
});

builder.Services.AddControllers().AddJsonOptions(o =>
{
    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var assemblies = AppDomain.CurrentDomain.GetAssemblies()
        .Where(a => a.GetName().Name!.StartsWith("Hospital"))
        .Distinct();

    foreach (var assembly in assemblies)
    {
        var xmlFile = $"{assembly.GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
            c.IncludeXmlComments(xmlPath);
    }

    c.UseInlineDefinitionsForEnums();
});

builder.AddMongoDBClient("hospital-client");

builder.Services.AddDbContext<HospitalDbContext>((services, o) =>
{
    var db = services.GetRequiredService<IMongoDatabase>();
    o.UseMongoDB(db.Client, db.DatabaseNamespace.DatabaseName);
});

builder.Services.AddHostedService<HospitalKafkaConsumer>();
builder.AddKafkaConsumer<Guid, IList<AppointmentCreateUpdateDto>>("hospital-kafka",
    configureBuilder: builder =>
    {
        builder.SetKeyDeserializer(new HospitalKeyDeserializer());
        builder.SetValueDeserializer(new HospitalValueDeserializer());
    },
    configureSettings: settings =>
    {
        settings.Config.GroupId = "hospital-consumer";
        settings.Config.AutoOffsetReset = Confluent.Kafka.AutoOffsetReset.Earliest;
    }
);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<HospitalDbContext>();

    if (!dbContext.Doctors.Any())
    {
        foreach (var spec in Initialization.Specializations)
            await dbContext.Specializations.AddAsync(spec);

        foreach (var doctor in Initialization.Doctors)
            await dbContext.Doctors.AddAsync(doctor);

        foreach (var patient in Initialization.Patients)
            await dbContext.Patients.AddAsync(patient);

        foreach (var appointment in Initialization.Appointments)
            await dbContext.Appointments.AddAsync(appointment);

        await dbContext.SaveChangesAsync();
    }
}

app.MapDefaultEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
