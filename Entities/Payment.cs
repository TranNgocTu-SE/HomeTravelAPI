namespace HomeTravelAPI.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public decimal? ToTalPrice { get; set; }
        public string? Method { get; set; }
        public bool? Status { get; set; }
        public Booking Booking { get; set; }
        public int BookingId { get; set; }
    }
}
