namespace HomeTravelAPI.Entities
{
    public class BookingDetail
    {
        public int RoomId { get; set; }
        public int BookingId { get; set; }
        public Room Room { get; set; }
        public Booking Booking { get; set; }
    }
}
