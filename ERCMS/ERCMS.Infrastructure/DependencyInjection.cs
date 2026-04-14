using ERCMS.Domain.Interfaces.Repositories;
using ERCMS.Infrastructure.DataAccess.Contexts;
using ERCMS.Infrastructure.DataAccess.Interceptors;
using ERCMS.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ERCMS.Infrastructure;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public void AddInfrastructure(IConfiguration configuration)
        {
            services.AddInterceptors();
            services.AddDbContexts(configuration);
            services.AddRepositories();
        }

        private void AddInterceptors()
        {
            services.AddSingleton<AuditEntitiesInterceptor>();
        }
        
        private void AddDbContexts(IConfiguration configuration)
        {
            services.AddDbContext<ErcmsDbContext>((sp, opt) =>
            {
                var interceptor = sp.GetRequiredService<AuditEntitiesInterceptor>();
                opt.UseSqlServer(configuration.GetConnectionString("Migration"))
                    .AddInterceptors(interceptor);
            });
        }

        private void AddRepositories()
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}