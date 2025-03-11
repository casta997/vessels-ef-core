using _001_aTestDI.GlobalInterfaces;
using _001_aTestDI.Services;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();

serviceCollection.AddTransient<INotification, EmailService>();
serviceCollection.AddTransient<INotification, SmsService>();
serviceCollection.AddTransient<INotification, PushService>();


var serviceProvider = serviceCollection.BuildServiceProvider();

var push = serviceProvider.GetService<INotification>();

push.Send("write third notification...");