using FindPets.Shared;

namespace FindPets.Server.Repositories
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> GetAll();
        Task<Pet> GetByIdAsync(Guid id);
        Task<Pet> AddAsync(Pet pet);
        Task<Pet> UpdateAsync(Pet pet);
        Task<bool> DeleteByIdAsync(Guid id);
    }
}
