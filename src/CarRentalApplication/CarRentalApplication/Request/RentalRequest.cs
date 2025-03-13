namespace CarRentalApplication.Request
{
    public class RentalRequest
    {
        public long CustomerId { get; set; }
        public string LicensePlate { get; set; } = "";
        public DateTime RentalDate { get; set; }
    }
}
