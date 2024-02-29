namespace HomeTravelAPI.Common
{
    public interface IImageService
    {
        public string UploadImageToAzure(IFormFile file);
    }
}
