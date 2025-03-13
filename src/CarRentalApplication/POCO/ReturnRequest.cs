using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.POCO;

public class ReturnRequest
{
    [Required]
    public string LicensePlate { get; set; } = "";
    [Required]
    public DateTime ReturnDate { get; set; } = DateTime.Now;
}