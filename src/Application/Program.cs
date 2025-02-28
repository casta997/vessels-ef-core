using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddData()
    .AddDomain()
    .AddHostedService<Worker>();

using var host = builder.Build();

host.Run();
