using CarRentalApplication.Context;
using CarRentalApplication.Interfaces;
using CarRentalApplication.Interfaces.RepositoriesInterfaces;
using CarRentalApplication.Repositories;
using CarRentalApplication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConnectionDb");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<IRentalService, RentalService>();
builder.Services.AddTransient<ICarService, CarService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddDbContext<CarRentalContext>(options => options.UseSqlServer(connectionString, d => d.MigrationsAssembly("CarRentalApplication")));

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
