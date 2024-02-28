namespace HomeTravelAPI.ViewModels
{
    public class UpdateUserModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public IFormFile Avatar { get; set; }
        public string Status { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string SecurityCode { get; set; }
        public string NameBank { get; set; }
        public string NumberBank { get; set; }
        public string AccountName { get; set; }
    }
}
