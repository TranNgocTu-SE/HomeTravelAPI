using HomeTravelAPI.Entities;

namespace HomeTravelAPI.ViewModels
{
    public class HomeStayViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Address { get; set; }
        public string Description { get; set;}
        public string Acreage { get; set; }
        public string Capacity { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Service> Services { get; set; } 
        public Policy Policy { get; set; }
        public List<ImageHome> ImageHomes { get; set; }    

    }
}
