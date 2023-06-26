namespace FindPets.Shared.Pets
{
    public interface IPetRepository
    {
        Task<List<Pet>> GetAll(SearchPet search);
        Task<Pet> GetByIdAsync(Guid id);
        Task<Pet> AddAsync(Pet pet);
        Task<Pet> UpdateAsync(Pet pet);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
