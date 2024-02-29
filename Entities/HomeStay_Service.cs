namespace HomeTravelAPI.Entities
{
    public class HomeStay_Service
    {
        public int HomeStayId { get; set; }
        public int ServiceId { get; set; }
        public HomeStay HomeStay { get; set; }
        public Service Service { get; set; }

    }
}
