using FindPets.Server.Data;
using FindPets.Shared.Pets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Drawing;

namespace FindPets.Server.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly FindPetsDBContext _context;

        public PetRepository(FindPetsDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pet>> GetAll(SearchPet search)
        {
            var skip = (search.Page - 1) * search.Take;

            if (search.Search == null)
                search.Search = "";

            var pets = await _context.Pets.Where(pet => pet.Status == search.Status &&
                                                   pet.Description.Contains(search.Search)
                                                   && (search.Type != null ? pet.AdType == search.Type: true)).OrderByDescending(pet => pet.CreatedAt)
                                                   .Skip(skip).Take(search.Take).ToListAsync();

            return pets;
        }

        public async Task<Pet> GetByIdAsync(Guid id)
        {
            var pet = await _context.Pets.SingleOrDefaultAsync(p => p.Id == id);

            return pet;
        }

        public async Task<Pet> AddAsync(Pet pet)
        {
            var newPet = _context.Pets.Add(pet).Entity;
            await _context.SaveChangesAsync();

            return newPet;
        }

        public async Task<Pet> UpdateAsync(Pet pet)
        {
            var updatedPet = _context.Pets.Update(pet).Entity;
            await _context.SaveChangesAsync();

            return updatedPet;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var pet = await GetByIdAsync(id);

            if (pet is null) return false;
            
            _context.Pets.Remove(pet);
            return await _context.SaveChangesAsync() > 0; 
        }
    }
}
