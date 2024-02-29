using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;

namespace HomeTravelAPI.Common
{
    public class ImageService : IImageService
    {
        private readonly AzureOption _azureOption;

        public ImageService(IOptions<AzureOption> azureOption)
        {
            _azureOption = azureOption.Value;
        }

        public string UploadImageToAzure(IFormFile file)
        {
            string fileExtension = Path.GetExtension(file.Name);
            string fileURL = null;
            BlobContainerClient container = new BlobContainerClient(_azureOption.ConnectionString, _azureOption.Container);
            try
            {
                var uniqueName = Guid.NewGuid().ToString() + fileExtension;
                BlobClient blob = container.GetBlobClient(uniqueName);
                using (Stream stream = file.OpenReadStream())
                {
                    blob.Upload(stream, new BlobUploadOptions()
                    {
                        HttpHeaders = new BlobHttpHeaders
                        {
                            ContentType = "image/jpg"
                        }
                    },cancellationToken:default);
                }
                fileURL = blob.Uri.AbsoluteUri;
                return fileURL;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
