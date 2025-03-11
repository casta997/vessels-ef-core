using _003_DI.IGlobalServices;
using _003_DI.IPersonalServices;
using _003_DI.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceDescriptors = new ServiceCollection();

serviceDescriptors.AddTransient<INotificationFactory, NotificationFactory>();
serviceDescriptors.AddTransient<IEmailService, EmailService>();
serviceDescriptors.AddTransient<IPushService, PushService>();
serviceDescriptors.AddTransient<ISmsService, SmsService>();
serviceDescriptors.AddTransient<Notification>();

var host = serviceDescriptors.BuildServiceProvider();

var notification = host.GetService<Notification>();

notification.Notify<IEmailService>("My first comment");
notification.Notify<IPushService>("My second comment");
notification.Notify<ISmsService>("My third comment");