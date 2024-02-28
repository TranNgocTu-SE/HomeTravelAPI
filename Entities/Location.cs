namespace HomeTravelAPI.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string? CityName { get; set; }
        public string? DistrictName { get; set; }
        public string? ProvinceName { get; set; }
        public string? StreetName { get; set; }
        public string? NumberHome { get; set; }
        public HomeStay HomeStay { get; set; }
        public int HomeStayId { get; set; }
    }
}
