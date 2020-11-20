using GrupoShemesh.Api.Helpers;
using GrupoShemesh.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GrupoShemesh.Api.Middleware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Inyectar los servicios del repositorio génerico
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IMailRepository, MailRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IImgService, ImgService>();
            services.AddScoped<IBaseUrl, BaseUrl>();
            services.AddScoped<IWeekyReportPanel, WeekyReportPanel>();
            return services;
        }
    }
}
