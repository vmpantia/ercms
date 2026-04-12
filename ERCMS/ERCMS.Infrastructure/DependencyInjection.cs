using ERCMS.Domain.Interfaces.Repositories;
using ERCMS.Infrastructure.DataAccess.Contexts;
using ERCMS.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERCMS.Infrastructure;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddInfrastructure(IConfiguration configuration)
        {
            services.AddDbContexts(configuration)
                    .AddRepositories();
            
            return services;
        }
        
        private IServiceCollection AddDbContexts(IConfiguration configuration)
        {
            services.AddDbContext<ErcmsDbContext>(opt => opt
                .UseSqlServer(configuration
                    .GetConnectionString("Migration")));

            return services;
        }

        private IServiceCollection AddRepositories()
        {
            services.AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IStudentRepository, StudentRepository>();
            
            return services;
        }
    }
}