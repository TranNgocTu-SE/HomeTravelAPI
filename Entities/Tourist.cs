using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeTravelAPI.Entities
{
    [Table("Tourists")]
    public class Tourist :AppUser
    {
        public string CartNumber { get; set; }
        public string NameOnCart { get; set; }
        public string SecurityCode { get; set; }

        public Collection<Booking> Bookings { get; set; }
        public Collection<FeedBack> FeedBacks { get; set; }
    }
}
