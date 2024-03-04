namespace HomeTravelAPI.Common
{
    public interface IMailService 
    {
        Task<bool> SendMail(string toEmail, string message);
    }
}
