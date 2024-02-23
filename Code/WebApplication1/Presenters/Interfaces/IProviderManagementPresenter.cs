using DesafioAutoglass.Views.CreateProvider.Request;

namespace DesafioAutoglass.Presenters.Interfaces
{
    public interface IProviderManagementPresenter
    {
        Task<long> CreateProvider(CreateProviderRequestDTO providerDto);
    }
}
