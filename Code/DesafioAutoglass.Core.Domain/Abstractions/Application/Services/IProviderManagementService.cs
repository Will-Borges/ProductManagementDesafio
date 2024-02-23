using DesafioAutoglass.Core.Domain.Entities.Providers;

namespace DesafioAutoglass.Core.Domain.Abstractions.Application.Services
{
    public interface IProviderManagementService
    {
        Task<long> CreateProvider(Provider provider);
        Task<Provider> GetProviderByCode(long code);
        Task VerifyProviderExistByCode(long code);
    }
}
