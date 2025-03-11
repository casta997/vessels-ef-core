using _001_DI.IServices;
using _001_DI.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceDescriptors = new ServiceCollection();

//serviceDescriptors.AddTransient<INotification, EmailService>();
//serviceDescriptors.AddTransient<INotification, PushService>();
serviceDescriptors.AddTransient<INotification, SmsService>();

var host = serviceDescriptors.BuildServiceProvider();

var smsService = host.GetService<INotification>();

smsService.Send("Hello world!");

serviceDescriptors.AddTransient<INotification, EmailService>();
var host1 = serviceDescriptors.BuildServiceProvider();

var email = host1.GetService<INotification>();

email.Send("New letter");