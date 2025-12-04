var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Hospital_Api_Host>("hospital-api-host");

builder.Build().Run();
