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
        public void AddInfrastructure(IConfiguration configuration)
        {
            services.AddDbContexts(configuration);
            services.AddRepositories();
        }
        
        private void AddDbContexts(IConfiguration configuration)
        {
            services.AddDbContext<ErcmsDbContext>(opt => opt
                .UseSqlServer(configuration
                    .GetConnectionString("Migration")));
        }

        private void AddRepositories()
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}