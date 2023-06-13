﻿using FindPets.Shared;

namespace FindPets.Server.Services
{
    public interface IPetService
    {
        Task<IEnumerable<Pet>> GetAllPets();
        Task<Pet> GetPetById(Guid id);
        Task<Pet> AddPet(Pet pet);
        Task<Pet> UpdatePet(Pet pet);
        Task<bool> DeletePet(Guid id);
    }
}
