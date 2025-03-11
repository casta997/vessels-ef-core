using _002_DI.IPersonalServices;
using _002_DI.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceDescriptors = new ServiceCollection();

serviceDescriptors.AddTransient<IEmailService, EmailService>();
serviceDescriptors.AddTransient<IPushService, PushService>();
serviceDescriptors.AddTransient<ISmsService, SmsService>();

var host = serviceDescriptors.BuildServiceProvider();

var emailService = host.GetService<IEmailService>();
var pushService = host.GetService<IPushService>();
var smsService = host.GetService<ISmsService>();

emailService.Send("First message");
pushService.Send("Second message");
smsService.Send("Third message");