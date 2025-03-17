using DI_webApiNotification_001.Data.Context;
using DI_webApiNotification_001.Data.Entities;
using DI_webApiNotification_001.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

var conString = builder.Configuration.GetConnectionString("Notification") ??
     throw new InvalidOperationException("Connection string 'BloggingContext'" +
    " not found.");
builder.Services.AddDbContext<NotificationContext>(options =>
options.UseSqlServer(conString));

//builder.Services.AddTransient<IEmail, Email>();
//builder.Services.AddTransient<IPush, Push>();
//builder.Services.AddTransient<ISms, Sms>();
builder.Services.AddTransient<INotification, Notification>();
builder.Services.AddTransient<IFactoryNotification, FactoryNotification>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
