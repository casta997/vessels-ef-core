using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Dto.Request;

public class CustomerModel
{
    [Required]
    public string Name { get; set; }
}
