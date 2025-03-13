using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.POCO;

public class CustomerPoco
{
    [Required]
    public string Name { get; set; }
}
