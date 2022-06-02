using Apep.Application.Contracts.Persistence;
using Apep.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Apep.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApepDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ApepDB;Trusted_Connection=True"));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IMediaItemRepository, MediaItemRepository>();

            return services;
        }
    }
}
