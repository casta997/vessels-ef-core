using CarRentalApplication.Interfaces.Entities;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Entities;

public class Car : IModel
{
    public long Id { get; set; }
    [Required]
    public string LicensePlate { get; set; }
    public bool IsRented { get; set; }
}