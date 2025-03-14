using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Dto;

public class CarPoco
{
    [Required]
    public string LicensePlate { get; set; }
    public bool IsRented { get; set; } = false;
}
