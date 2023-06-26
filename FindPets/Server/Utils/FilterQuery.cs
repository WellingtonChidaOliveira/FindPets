using FindPets.Shared.Enum;
using FindPets.Shared.Pets;
using Microsoft.EntityFrameworkCore;

namespace FindPets.Server.Utils;

public static class FilterQuery
{
    public static IQueryable<Pet> FiltersPet(DbSet<Pet> contextPets, SearchPet search)
    {
        var query = contextPets.AsQueryable();
        query = query.Where(pet => pet.Status == search.Status);
        if(!string.IsNullOrWhiteSpace(search.Search))
            query = query.Where(pet => pet.Description.Contains(search.Search));
        if (search.Type != EnumTypeSearch.Todos) 
            query = query.Where(pet => pet.AdType == search.Type);

        return query;
    }
    
}