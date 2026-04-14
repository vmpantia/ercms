using System.Text;
using ERCMS.Application.Authentication;
using ERCMS.Application.Features.Students.CreateStudent;
using ERCMS.Application.Features.Students.GetStudentById;
using ERCMS.Application.Features.Students.GetStudents;
using ERCMS.Application.Features.Users.GetUsers;
using ERCMS.Application.Features.Users.LoginUser;
using ERCMS.Application.Features.Users.RegisterUser;
using ERCMS.Domain.Interfaces.Authentication;
using ERCMS.Domain.Requests;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace ERCMS.Application;

public static class DependencyInjection
{
    extension(IServiceCollection services)
    {
        public void AddApplication(IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);
            services.AddCustomAuthentication(configuration);
            services.AddRequestHandlers();
        }
        
        private void AddCustomAuthentication(IConfiguration configuration)
        {
            var authenticationSetting = AuthenticationSetting.Initialize(configuration);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.RequireHttpsMetadata = true;
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSetting.AccessToken.Secret)),
                        ValidIssuer = authenticationSetting.AccessToken.Issuer,
                        ValidAudience = authenticationSetting.AccessToken.Audience,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            
            services.AddSingleton(authenticationSetting);
            services.AddScoped<ITokenProvider, TokenProvider>();
        }

        private void AddRequestHandlers()
        {
            services.AddScoped<IRequestHandler<LoginUserCommand>, LoginUserCommandHandler>();
            services.AddScoped<IRequestHandler<RegisterUserCommand>, RegisterUserCommandHandler>();
            services.AddScoped<IRequestHandler<GetUsersQuery>, GetUsersQueryHandler>();
            services.AddScoped<IRequestHandler<CreateStudentCommand>, CreateStudentCommandHandler>();
            services.AddScoped<IRequestHandler<GetStudentsQuery>, GetStudentsQueryHandler>();
            services.AddScoped<IRequestHandler<GetStudentByIdQuery>, GetStudentByIdQueryHandler>();
        }

    }
}