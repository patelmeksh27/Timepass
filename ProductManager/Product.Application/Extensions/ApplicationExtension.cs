using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Contract;
using Project.Application.JwtSetting;
using Project.Application.Services;
using Project.Infrastructure.Services;
using Microsoft.Extensions.Options;

namespace Project.Application.Extensions
{
    public static class AppServiceExtension
    {
        public static void AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthService, AuthService>();

            services.Configure<JwtSettings>(
                configuration.GetSection("Jwt")
            );
        }
    }
}