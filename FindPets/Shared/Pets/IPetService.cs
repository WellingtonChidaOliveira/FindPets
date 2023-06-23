namespace FindPets.Shared.Pets
{
    public interface IPetService
    {
        Task<List<Pet>> GetAllPets(SearchPet search);
        Task<Pet> GetPetById(Guid id);
        Task<Pet> AddPet(Pet pet);
        Task<Pet> UpdatePet(Pet pet);
        Task<bool> DeletePet(Guid id);
    }
}
