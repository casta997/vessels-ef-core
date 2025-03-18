using CarRentalApplication.Context;
using CarRentalApplication.Entities;
using CarRentalApplication.Interfaces.Entities;
using CarRentalApplication.Interfaces.Repositories;
using CarRentalApplication.Interfaces.Services;
using CarRentalApplication.Repositories;
using CarRentalApplication.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("CarRentalConnection") ??
    throw new InvalidOperationException("Connection string 'CarRentalConnection'" +
    " not found.");

// Add services to the container.
builder.Services
    .AddDbContext<CarRentalContext>(options => options.UseSqlServer(connectionString))
    .AddTransient<ICarRepository, CarRepository>()
    .AddTransient<ICustomerRepository, CustomerRepository>()
    .AddTransient<IRentalRepository, RentalRepository>()
    .AddTransient<ICommonRepository, CarRepository>()
    .AddTransient<IRepositoryFactory, RepositoryFactory>()
    .AddTransient<ICarService, CarService>()
    .AddTransient<ICustomerService, CustomerService>()
    .AddTransient<IRentalService, RentalService>();
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
