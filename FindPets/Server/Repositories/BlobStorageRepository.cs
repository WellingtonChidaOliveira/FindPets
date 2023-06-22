using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using FindPets.Shared.Pets;
using Microsoft.IdentityModel.Tokens;

namespace FindPets.Server.Repositories
{
    public class BlobStorageRepository : IBlobStorageRepository
    {

        private readonly string _storageConnectionString;
        private readonly string _storageContainerName;

        public BlobStorageRepository(IConfiguration configuration)
        {
            _storageConnectionString = configuration.GetValue<string>("Azure:BlobConnectionString");
            _storageContainerName = configuration.GetValue<string>("Azure:BlobContainerName");
        }

        public bool DeleteImage(Pet pet)
        {
            BlobContainerClient blobContainer = new BlobContainerClient(_storageConnectionString, _storageContainerName);

            string blobId = pet.ImageUrl.Split("/").LastOrDefault();

            BlobClient blobClient = blobContainer.GetBlobClient(blobId);
            try
            {
                blobClient.Delete();
                return true;
            }
            catch (RequestFailedException ex)
               when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                return false;
            }
        }

        public string UpdateImage(Pet pet)
        {
            BlobContainerClient blobContainer = new BlobContainerClient(_storageConnectionString, _storageContainerName);

            string blobId = pet.ImageUrl.Split("/").LastOrDefault();

            BlobClient blobClient = blobContainer.GetBlobClient(blobId);
            try
            {
                blobClient.Delete();
                return UploadImage(pet);
                
            }
            catch (RequestFailedException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public string UploadImage(Pet pet)
        {
            if (pet.Photo.IsNullOrEmpty())
                return string.Empty;

            var fileName = Guid.NewGuid().ToString() + "." + pet.PhotoExtension;
            var blobClient = new BlobClient(_storageConnectionString, _storageContainerName, fileName);

            using (var stream = new MemoryStream(pet.Photo))
            {

                blobClient.Upload(stream);
            }

            return blobClient.Uri.AbsoluteUri;
        }
    }
}
