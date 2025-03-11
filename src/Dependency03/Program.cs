using Dependency03;
using Dependency03.Interfaces;
using Dependency03.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddTransient<INotificationFactory, NotificationFactory>()
    .AddTransient<Notification>()
    .AddTransient<EmailService>()
    .AddTransient<SmsService>()
    .AddTransient<PushService>();

var host = builder.Build();

var sendMessage = host.Services.GetService<Notification>();
sendMessage.Notify<EmailService>("->");
sendMessage.Notify<SmsService>("->");
sendMessage.Notify<PushService>("->");
