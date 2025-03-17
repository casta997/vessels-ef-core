using CarRentalApplication.Interfaces.Entities;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Entities;

public class Customer : IModel
{
    public long Id { get; set; }
    [Required]
    public string Name { get; set; }
}
