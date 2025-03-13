using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.POCO;

public class CarPoco
{
    [Required]
    public string LicensePlate { get; set; }
    public bool IsRented { get; set; } = false;
}
