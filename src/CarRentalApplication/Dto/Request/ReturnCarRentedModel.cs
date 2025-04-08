using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Dto;

public class ReturnCarRentedModel
{
    [Required]
    public string LicensePlate { get; set; } = "";
    [Required]
    public DateTime ReturnDate { get; set; } = DateTime.Now;
}