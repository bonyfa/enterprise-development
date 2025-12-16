using Hospital.Application.Contracts.Appointments;
using Hospital.Generator.Kafka.Host;
using Hospital.Generator.Kafka.Host.Interfaces;
using Hospital.Generator.Kafka.Host.Serializers;

var builder = WebApplication.CreateBuilder(args);

builder.AddKafkaProducer<Guid, IList<AppointmentCreateUpdateDto>>(
    "hospital-kafka",
    kafkaBuilder =>
    {
        kafkaBuilder.SetKeySerializer(new HospitalKeySerializer());
        kafkaBuilder.SetValueSerializer(new HospitalValueSerializer());
    });

builder.AddServiceDefaults();

builder.Services.AddScoped<IProducerService, HospitalKafkaProducer>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var assemblies = AppDomain.CurrentDomain.GetAssemblies()
    .Where(a => a.GetName().Name!.StartsWith("Hospital"))
    .Distinct();

    foreach (var assembly in assemblies)
    {
        var xmlFile = $"{assembly.GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        if (File.Exists(xmlPath))
            options.IncludeXmlComments(xmlPath);
    }
});

var app = builder.Build();

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
