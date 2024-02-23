namespace HomeTravelAPI.Entities
{
    public class Refund
    {
        public int RefundId { get; set; }
        public decimal PaidAmount { get; set; }
        public string Reason { get; set; }
        public DateTime ReceiveDate { get; set; }
        public string Status { get; set; }
        public Payment Payment { get; set; }
        public int PaymentId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
