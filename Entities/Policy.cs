namespace HomeTravelAPI.Entities
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyTitle { get; set; }
        public string Common {  get; set; }
        public string Accessablility { get; set; }
        public string Business { get; set; }
        public string Connectivity { get; set; }
        public string FoodAndDrink { get; set; }
        public string InsideRoom { get; set; }
        public string NearbyAmenities { get; set; }
        public string SportsAndRecreation { get; set; }
        public string ThingsToDo { get; set; }
        public string Transportation { get; set; }
        public bool Status { get; set; }
        public HomeStay HomeStay { get; set; }
        public int HomeStayId { get; set; }
    }
}
