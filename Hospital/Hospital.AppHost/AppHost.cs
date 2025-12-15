var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddMongoDB("mongo-container").AddDatabase("mongo-db");

var apiHost = builder.AddProject<Projects.Hospital_Api_Host>("hospital-api-host")
    .WithReference(db, "hospital-client")
    .WaitFor(db);

var kafka = builder.AddKafka("hospital-kafka")
        .WithKafkaUI();

var kafkaTopic = builder.AddParameter("KafkaTopic");

apiHost.WithEnvironment("Kafka:TopicName", kafkaTopic)
    .WithReference(kafka)
    .WaitFor(kafka);

builder.Build().Run();