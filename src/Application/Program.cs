using Dependency01.Interfaces;
using Dependency01.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

builder.Services
    .AddTransient<INotificationService, EmailService>();

var host = builder.Build();

var sendMessage = host.Services.GetService<INotificationService>();
sendMessage.Send("-> ");
