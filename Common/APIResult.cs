namespace HomeTravelAPI.Common
{
    public class APIResult
    {
        public APIResult(int Status,String Message)
        {
            this.Status= Status;
            this.Message= Message;
        }

        public APIResult(int Status, String Message,object Data)
        {
            this.Status = Status;
            this.Message = Message;
            this.Data = Data;
        }

        public int Status { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }


    }
}
