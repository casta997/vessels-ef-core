namespace CarRentalApplication.Request
{
    public class UpdateRentalRequest
    {
        public long RentalId { get; set; }
        public long CarId { get; set; }
        public long CustomerId { get; set; }
        
        public DateTime RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
