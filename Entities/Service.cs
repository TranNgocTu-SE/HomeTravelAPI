namespace HomeTravelAPI.Entities
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool? Status { get; set; }

        //
        public ICollection<HomeStay_Service> HomeStay_Services { get; set; }

        public Booking Booking { get; set; }
    }
}
