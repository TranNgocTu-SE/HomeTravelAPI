namespace HomeTravelAPI.Entities
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string? PolicyTitle { get; set; }
        public string? PolicyDescription { get; set; }
        public bool? Status { get; set; }
        public HomeStay HomeStay { get; set; }
        public int HomeStayId { get; set; }
    }
}
