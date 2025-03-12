namespace CarRentalApplication.Entities;

public class Rental
{
    public long Id { get; set; }
    public long CarId { get; set; }
    public long CustomerId { get; set; }
    public DateTime RentalDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}
