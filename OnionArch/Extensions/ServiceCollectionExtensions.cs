using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Persistant;
using Persistant.Repositories;
using Service.Abstraction;
using Services;

namespace API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("Local") ?? throw new InvalidOperationException("Database Connection String is not configured."); ;

            // repositories
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            // services
            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddDbContext<RepositoryDbContext>(options =>
            options.UseSqlServer(connectionString)
            );

            return services;

        }
    }
}
