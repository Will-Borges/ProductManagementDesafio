using AutoMapper;

namespace DesafioAutoglass.Presenters
{
    using DesafioAutoglass.Core.Domain.Abstractions.Application.Services;
    using DesafioAutoglass.Core.Domain.Entities.Products;
    using DesafioAutoglass.Core.Domain.Entities.Providers;
    using DesafioAutoglass.Presenters.Interfaces;
    using DesafioAutoglass.Views.CreateProduct.Request;
    using DesafioAutoglass.Views.UpdateProduct.Request;

    public class ProductManagementPresenter : IProductManagementPresenter
    {
        private readonly IMapper _mapper;
        private readonly IProductManagementService _productManagementService;

        public ProductManagementPresenter(IMapper mapper, IProductManagementService productManagementService)
        {
            _mapper = mapper;
            _productManagementService = productManagementService;
        }


        public async Task<long> CreateProduct(CreateProductRequestDTO productDto)
        {
            if (productDto == null)
            {
                return 0;
            }

            var product = BuildProduct(productDto);
            ValidManufacturingDate(product);

            var productCode = await _productManagementService.CreateProduct(product);
            return productCode;
        }

        public async Task<Product> GetProductById(long productCode)
        {
            if (productCode == 0)
            {
                throw new InvalidOperationException("ProductCode cannot be zero.");
            }

            var product = await _productManagementService.GetProductByCode(productCode);
            return product;
        }

        public async Task<Product[]> GetAllProducts(int? pageNumber = null, int? pageSize = null)
        {
            var products = await _productManagementService.GetAllProducts(pageNumber, pageSize);
            return products;
        }

        public async Task<bool> PutProductByCode(UpdateProductRequestDTO productDto)
        {
            if (productDto == null)
            {
                throw new InvalidOperationException("Product cannot be null.");
            }

            var product = BuildProduct(productDto);

            var productCodeResult = await _productManagementService.PutProductByCode(product);
            return productCodeResult;
        }

        public async Task<bool> DeleteProductByCode(long productCode)
        {
            if (productCode == 0)
            {
                throw new InvalidOperationException("ProductCode cannot be zero.");
            }

            var result = await _productManagementService.DeleteProductByCode(productCode);
            return result;
        }

        private void ValidManufacturingDate(Product product)
        {
            if (!product.ManufacturingDateIsValid(product.ManufacturingDate, product.ExpirationDate))
                throw new InvalidOperationException("ManufacturingDate has a date greater than ExpirationDate");
        }

        private Product BuildProduct(CreateProductRequestDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            var provider = new Provider(productDto.ProviderCode);
            product.InsertProvider(provider);

            return product;
        }

        private Product BuildProduct(UpdateProductRequestDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            var provider = new Provider(productDto.ProviderCode);
            product.InsertProvider(provider);

            return product;
        }
    }
}
