namespace HomeTravelAPI.Common
{
    public class APIResult
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }
        public Object? Orther {  get; set; }

    }
}
