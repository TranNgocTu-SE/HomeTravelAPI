namespace HomeTravelAPI.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime OrderDate { get; set; }
        public int NumberOfTourist { get; set; }
        public string ContractDescription { get; set; }
        public string RentalStartDate { get; set; }
        public string RentalEndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Boolean Status { get; set; }

        public Tourist Tourist { get; set; }
        public int TouristId { get; set; }
        //public HomeStay HomeStay { get; set; }
        //public int HomeStayId { get; set; }

        public Room Room { get; set; }
        public int RoomId { get; set;}
        public ICollection<Service> Services { get; set; }
    }
}
