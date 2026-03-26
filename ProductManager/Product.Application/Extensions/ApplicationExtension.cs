using Microsoft.Extensions.DependencyInjection;
using Project.Application.Contract;
using Project.Application.Services;

namespace Project.Application.Extensions;

public static class AppServiceExtension
{
    public static void AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IAuthService, AuthService>();
    }
}