using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Dto;

public class CustomerPoco
{
    [Required]
    public string Name { get; set; }
}
