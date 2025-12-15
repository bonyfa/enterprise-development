var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddMongoDB("mongo-container").AddDatabase("mongo-db");

var apiHost = builder.AddProject<Projects.Hospital_Api_Host>("hospital-api-host")
    .WithReference(db, "hospital-client")
    .WaitFor(db);

var kafka = builder.AddKafka("hospital-kafka")
        .WithKafkaUI()
        .WithEnvironment("KAFKA_AUTO_CREATE_TOPICS_ENABLE", "true");

var kafkaTopic = builder.AddParameter("KafkaTopic");
var kafkaGenerator = builder.AddProject<Projects.Hospital_Generator_Kafka_Host>("hospital-generator-kafka-host")
    .WithReference(kafka)
    .WithReference(apiHost)
    .WaitFor(kafka)
    .WaitFor(apiHost)
    .WithEnvironment("Kafka:TopicName", kafkaTopic);

apiHost.WithEnvironment("Kafka:TopicName", kafkaTopic)
    .WithReference(kafka)
    .WaitFor(kafka)
    .WaitFor(kafkaGenerator);

builder.Build().Run();