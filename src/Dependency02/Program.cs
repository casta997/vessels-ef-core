using Dependency02.Interfaces;
using Dependency02.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

builder.Services
    .AddTransient<IPushService, PushService>()
    .AddTransient<ISmsService, SmsService>()
    .AddTransient<IEmailService, EmailService>();

var host = builder.Build();

var sendMessagePush = host.Services.GetService<IPushService>();
sendMessagePush.Send("-> ");

var sendMessageEmail = host.Services.GetService<IEmailService>();
sendMessageEmail.Send("-> ");

var sendMessageSms = host.Services.GetService<ISmsService>();
sendMessageSms.Send("-> ");
