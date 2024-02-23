using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeTravelAPI.Entities
{
    [Table("Owners")]
    public class Owner : AppUser
    {
        public string NameBank { get; set; }
        public string NumberBank { get; set; }
        public string AccountName { get; set; }

        public Collection<HomeStay> HomeStays { get; set; }
    }
}
