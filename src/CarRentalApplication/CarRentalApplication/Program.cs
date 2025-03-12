using CarRentalApplication.Context;
using CarRentalApplication.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConnectionDb");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<RentalService>();
builder.Services.AddTransient<CarService>();
builder.Services.AddTransient<CustomerService>();
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
