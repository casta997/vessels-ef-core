using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Dto;

public class ReturnRequest
{
    [Required]
    public string LicensePlate { get; set; } = "";
    [Required]
    public DateTime ReturnDate { get; set; } = DateTime.Now;
}