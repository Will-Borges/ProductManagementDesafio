using AutoMapper;
using DesafioAutoglass.Adapters.Persistence.Adapters.Repositories.Interfaces;
using DesafioAutoglass.Core.Domain.Abstractions.Application.Services;
using DesafioAutoglass.Core.Domain.Abstractions.Repository;
using DesafioAutoglass.Core.Domain.DesafioAutoglass.Entities;
using DesafioAutoglass.Core.Domain.Entities.Providers;

namespace DesafioAutoglass.Core.Application.Services
{
    public class ProviderManagementService : IProviderManagementService
    {
        private readonly IMapper _mapper;
        private readonly IEntityWriteRepository<ProviderEntity> _providerEntityWriteRepository;
        private readonly IEntityReadRepository<ProviderEntity> _providerEntityReadRepository;


        public ProviderManagementService(IMapper mapper,
            IEntityWriteRepository<ProviderEntity> providerEntityWriteRepository,
            IEntityReadRepository<ProviderEntity> providerEntityReadRepository)
        {
            _mapper = mapper;
            _providerEntityWriteRepository = providerEntityWriteRepository;
            _providerEntityReadRepository = providerEntityReadRepository;
        }

        public async Task<Provider> GetProviderByCode(long code)
        {
            if (code == 0)
                throw new InvalidOperationException("Provider code is empty");

            try
            {
                var providerEntity = await _providerEntityReadRepository.Get(code);
                var provider = _mapper.Map<Provider>(providerEntity);

                return provider;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when searching product");
            }
        }

        public async Task VerifyProviderExistByCode(long code)
        {
            try
            {
                var providerEntity = await _providerEntityReadRepository.Get(code);

                if (providerEntity == null)
                    throw new InvalidOperationException("The provider does not exist with this code");
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when searching for provider");
            }
        }

        public async Task<long> CreateProvider(Provider provider)
        {
            try
            {
                var providerEntity = _mapper.Map<ProviderEntity>(provider);
                var providerCode = await _providerEntityWriteRepository.Create(providerEntity);

                return providerCode;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when creating provider");
            }
        }
    }
}