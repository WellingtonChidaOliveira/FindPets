using FindPets.Shared.Pets;
using FindPets.Shared.Users;
using Microsoft.EntityFrameworkCore;

namespace FindPets.Server.Data
{
    public class FindPetsDBContext : DbContext
    {
        public FindPetsDBContext(DbContextOptions<FindPetsDBContext> options) : base(options)
        {
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
