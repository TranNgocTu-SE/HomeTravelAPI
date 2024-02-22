using System.Collections.ObjectModel;

namespace HomeTravelAPI.Entities
{
    public class Owner
    {
        public int OwnerId { get; set; }
        public string NameBank { get; set; }
        public string NumberBank { get; set; }
        public string AccountName { get; set; }

        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public Collection<HomeStay> HomeStays { get; set; }
    }
}
