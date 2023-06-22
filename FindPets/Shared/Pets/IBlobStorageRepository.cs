namespace FindPets.Shared.Pets
{
    public interface IBlobStorageRepository
    {
        string UploadImage(Pet pet);
        string UpdateImage(Pet pet);
        bool DeleteImage(Pet pet);
        
    }
}
