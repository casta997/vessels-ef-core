using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Entities;

public class Car
{
    public long Id { get; set; }
    [Required]
    public string LicensePlate { get; set; }
    public bool IsRented { get; set; }
}