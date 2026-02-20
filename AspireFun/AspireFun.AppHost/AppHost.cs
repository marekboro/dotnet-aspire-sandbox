var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddProject<Projects.AspireFun_Server>("server")
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints();

var angularFrontend = builder.AddJavaScriptApp("frontend", "../AngularFrontend")
    .WithHttpEndpoint(targetPort: 4200, env: "PORT", isProxied: false)
    .WithReference(server)
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

server.PublishWithContainerFiles(angularFrontend, "wwwroot");

builder.Build().Run();
