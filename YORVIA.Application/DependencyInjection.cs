using YORVIA.Application.Features.Authentication.Interfaces;
using YORVIA.Application.Features.Authentication.Services;
using Microsoft.Extensions.DependencyInjection;
namespace YORVIA.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ILoginServise, LoginService>();
            services.AddScoped<IRegisterService, RegisterService>();
            return services;
        }

    }
}
