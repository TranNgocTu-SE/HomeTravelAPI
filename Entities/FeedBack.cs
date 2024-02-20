namespace HomeTravelAPI.Entities
{
    public class FeedBack
    {
        public int FeedBackId { get; set; }
        public string? Description { get; set; }
        public DateTime? FeedBackDate { get; set; }
        public decimal? Rate { get; set; }
        public bool? Status { get; set; }
    }
}
