using Azure.Storage.Blobs;
using FindPets.Server.Repositories;
using FindPets.Shared.Pets;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FindPets.Server.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IBlobStorageRepository _blobStorageRepository;

      

        public PetService(IPetRepository petRepository, IBlobStorageRepository blobStorageRepository)
        {
            _petRepository = petRepository;
            _blobStorageRepository = blobStorageRepository;
           
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
            if(!pet.Photo.IsNullOrEmpty())
                pet.ImageUrl = _blobStorageRepository.UploadImage(pet);
            
            return await _petRepository.AddAsync(pet);
        }

        public async Task<Pet> UpdatePet(Pet pet)
        {
            if (!pet.Photo.IsNullOrEmpty())
                pet.ImageUrl = _blobStorageRepository.UpdateImage(pet);

            return await _petRepository.UpdateAsync(pet);
        }

        public async Task<bool> DeletePet(Guid id)
        {

            return await _petRepository.DeleteByIdAsync(id);
        }
    }
}
