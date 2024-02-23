using AutoMapper;

namespace DesafioAutoglass.Automapper
{
    using DesafioAutoglass.Core.Domain.DesafioAutoglass.Entities;
    using DesafioAutoglass.Core.Domain.Entities.Products;
    using DesafioAutoglass.Core.Domain.Entities.Providers;
    using DesafioAutoglass.Views.CreateProduct.Request;
    using DesafioAutoglass.Views.CreateProvider.Request;
    using DesafioAutoglass.Views.UpdateProduct.Request;

    public class DesafioAutoglassProfile : Profile
    {
        public DesafioAutoglassProfile()
        {
            // Products
            CreateMap<UpdateProductRequestDTO, Product>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (ProductStatus)src.Status));

            CreateMap<CreateProductRequestDTO, Product>();

            CreateMap<Product, ProductEntity>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status))
                .ForMember(dest => dest.ProviderCode, opt => opt.MapFrom(src => src.Provider.Code));

            CreateMap<ProductEntity, Product>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (ProductStatus)src.Status))
                .ForMember(dest => dest.ManufacturingDate, opt => opt.MapFrom(src => src.ManufacturingDate))
                .ForMember(dest => dest.ExpirationDate, opt => opt.MapFrom(src => src.ExpirationDate));


            // Provider
            CreateMap<CreateProviderRequestDTO, Provider>();
            CreateMap<Provider, ProviderEntity>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(src => src.CNPJ));

            CreateMap<ProviderEntity, Provider>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CNPJ, opt => opt.MapFrom(src => src.CNPJ));
        }
    }
}
