namespace CarRentalApplication.Request
{
    public class ReturnRequest
    {
        public string LicensePlate { get; set; } = "";
        public DateTime ReturnDate { get; set; }
    }
}
