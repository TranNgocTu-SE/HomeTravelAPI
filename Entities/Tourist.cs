using System.Collections.ObjectModel;

namespace HomeTravelAPI.Entities
{
    public class Tourist
    {
        public int TouristId { get; set; }
        public string CartNumber { get; set; }
        public string NameOnCart { get; set; }
        public string SecurityCode { get; set; }

        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public Collection<Booking> Bookings { get; set; }
        public Collection<FeedBack> FeedBacks { get; set; }
    }
}
