using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace HomeTravelAPI.Entities
{
    public class HomeStay
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int HomeStayId { get; set; }
        public string HomeStayName { get; set; }
        public string Description { get; set; }
        public string Acreage { get; set; }
        public int TotalCapacity { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }

        //
        public  ICollection<HomeStay_Service> HomeStay_Services { get; set; }
        public Policy Policy { get; set; }
        public Location Location { get; set; }
        public ICollection<ImageHome> ImageHomes { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public Owner Owner { get; set; }
    }
}
