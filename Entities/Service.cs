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
        public HomeStay HomeStay { get; set; }
        public int HomeStayId { get; set; }

        public Booking Booking { get; set; }
    }
}
