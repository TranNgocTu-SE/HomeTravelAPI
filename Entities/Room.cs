namespace HomeTravelAPI.Entities
{
    public class Room
    {
        public int RoomId { get; set; }
        public int PriceEarlyBook { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
    }
}
