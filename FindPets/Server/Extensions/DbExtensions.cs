using FindPets.Server.Data;
using FindPets.Server.Repositories;
using FindPets.Shared.Pets;
using Microsoft.EntityFrameworkCore;

namespace FindPets.Server.Extensions
{
    public static class DbExtensions
    {
        public static void AddDbServices(this IServiceCollection services, IConfiguration configuration)
        {
            var sectionName = "FindPetsDBConnection";
            var connectionStringDb = configuration.GetConnectionString(sectionName);

            services.AddDbContext<FindPetsDBContext>(options => {
                options.UseSqlServer(connectionStringDb);
            });

            AddRepositories(services);
        }

        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                using (var dbContext = scope.ServiceProvider.GetRequiredService<FindPetsDBContext>())
                {
                    dbContext.Database.Migrate();
                }
            }

            return app;
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IPetRepository, PetRepository>();
        }
    }
}