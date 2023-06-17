using FindPets.Shared.Pets;

namespace FindPets.Server.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<IEnumerable<Pet>> GetAllPets(SearchPet search)
        {
            return await _petRepository.GetAll(search);
        }

        public async Task<Pet> GetPetById(Guid id)
        {
            return await _petRepository.GetByIdAsync(id);
        }

        public async Task<Pet> AddPet(Pet pet)
        {
            return await _petRepository.AddAsync(pet);
        }

        public async Task<Pet> UpdatePet(Pet pet)
        {
            return await _petRepository.UpdateAsync(pet);
        }

        public async Task<bool> DeletePet(Guid id)
        {
            return await _petRepository.DeleteByIdAsync(id);
        }
    }
}
