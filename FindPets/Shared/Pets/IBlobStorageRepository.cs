namespace FindPets.Shared.Pets
{
    public interface IBlobStorageRepository
    {
        string UploadImage(byte[] image);
        string UpdateImage(byte[] image, string imgUrl);
        bool DeleteImage(string imgUrl);
        
    }
}
