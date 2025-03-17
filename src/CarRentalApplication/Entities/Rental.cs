using CarRentalApplication.Interfaces.Entities;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Entities;

public class Rental : IModel
{
    public long Id { get; set; }
    [Required]
    public long CarId { get; set; }
    [Required]
    public long CustomerId { get; set; }
    [Required]
    public DateTime RentalDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
