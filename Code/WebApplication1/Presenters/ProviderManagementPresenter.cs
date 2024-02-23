using AutoMapper;
using DesafioAutoglass.Core.Domain.Abstractions.Application.Services;
using DesafioAutoglass.Core.Domain.Entities.Providers;
using DesafioAutoglass.Presenters.Interfaces;
using DesafioAutoglass.Views.CreateProvider.Request;

namespace DesafioAutoglass.Presenters
{
    public class ProviderManagementPresenter : IProviderManagementPresenter
    {
        private readonly IMapper _mapper;
        private readonly IProviderManagementService _providerManagementService; 


        public ProviderManagementPresenter(IMapper mapper, IProviderManagementService providerManagementService)
        {
            _mapper = mapper;
            _providerManagementService = providerManagementService;
        }


        public async Task<long> CreateProvider(CreateProviderRequestDTO providerDto)
        {
            if (providerDto == null)
            {
                throw new InvalidOperationException("Provider cannot be null.");
            }

            var provider = BuildProvider(providerDto);

            var providerCode = await _providerManagementService.CreateProvider(provider);
            return providerCode;
        }

        private Provider BuildProvider(CreateProviderRequestDTO providerDto)
        {
            var provider = _mapper.Map<Provider>(providerDto);
            return provider;
        }
    }
}
