namespace DesafioAutoglass.Adapters.Persistence.Ioc
{
    using DesafioAutoglass.Adapters.Persistence.Adapters.Repositories.Default;
    using DesafioAutoglass.Adapters.Persistence.Adapters.Repositories.Interfaces;
    using DesafioAutoglass.Core.Domain.Abstractions.Repository;
    using Microsoft.Extensions.DependencyInjection;

    public static class AdapterModuleExtensions
    {
        public static IServiceCollection AddPersistenceRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEntityReadRepository<>), typeof(DapperReadRepository<>));
            services.AddScoped(typeof(IEntityWriteRepository<>), typeof(DapperWriteRepository<>));

            return services;
        }
    }
}
