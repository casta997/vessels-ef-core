using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Dto.Request;

public class CarModel
{
    [Required]
    public string LicensePlate { get; set; }
    public bool IsRented { get; set; }
}
