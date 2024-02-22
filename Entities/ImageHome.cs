namespace HomeTravelAPI.Entities
{
    public class ImageHome
    {
        public int ImageHomeId { get; set; }
        public string ImageURL { get; set; }
        public HomeStay HomeStay { get; set; }
        public int HomeStayId { get; set; }
    }
}
