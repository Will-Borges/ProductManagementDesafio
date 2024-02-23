using Microsoft.Extensions.DependencyInjection;

namespace DesafioAutoglass.Core.Application.Ioc
{
    using DesafioAutoglass.Core.Application.Services;
    using DesafioAutoglass.Core.Domain.Abstractions.Application.Services;

    public static class ApplicationModuleExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductManagementService, ProductManagementService>();
            services.AddScoped<IProviderManagementService, ProviderManagementService>();

            return services;
        }
    }
}
