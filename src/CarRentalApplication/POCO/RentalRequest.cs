using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.POCO;

public class RentalRequest
{
    [Required]
    public string LicensePlate { get; set; } = "";
    [Required]
    public long CustomerId { get; set; }
    [Required]
    public DateTime RentalDate { get; set; } = DateTime.Now;
}
