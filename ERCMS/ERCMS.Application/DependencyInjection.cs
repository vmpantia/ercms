using ERCMS.Application.Users.GetUsers;
using ERCMS.Application.Users.RegisterUser;
using ERCMS.Domain.Requests;
using Microsoft.Extensions.DependencyInjection;

namespace ERCMS.Application;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddApplication()
        {
            services.AddRequestHandlers();
            
            return services;
        }

        private IServiceCollection AddRequestHandlers()
        {
            services.AddScoped<IRequestHandler<GetUsersQuery>, GetUsersQueryHandler>()
                .AddScoped<IRequestHandler<RegisterUserCommand>, RegisterUserCommandHandler>();
            
            return services;
        }
    }
}