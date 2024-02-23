namespace DesafioAutoglass.Ioc
{
    using DesafioAutoglass.Presenters;
    using DesafioAutoglass.Presenters.Interfaces;

    public static class PortsModuleExtensions
    {
        public static IServiceCollection AddPortsPresenters(this IServiceCollection services)
        {
            services.AddScoped<IProductManagementPresenter, ProductManagementPresenter>();
            services.AddScoped<IProviderManagementPresenter, ProviderManagementPresenter>();

            return services;
        }
    }
}
