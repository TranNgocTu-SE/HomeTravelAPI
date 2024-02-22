using System.Collections.ObjectModel;

namespace HomeTravelAPI.Entities
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; }
        public Collection<Room> Rooms { get; set; }
    }
}
