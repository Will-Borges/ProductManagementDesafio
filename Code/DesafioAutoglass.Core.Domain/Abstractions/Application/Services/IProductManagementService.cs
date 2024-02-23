using DesafioAutoglass.Core.Domain.Entities.Products;

namespace DesafioAutoglass.Core.Domain.Abstractions.Application.Services
{
    public interface IProductManagementService
    {
        Task<long> CreateProduct(Product product);
        Task<Product> GetProductByCode(long code);
        //Task<Product[]> GetAllProducts();
        Task<Product[]> GetAllProducts(int? pageNumber = null, int? pageSize = null);
        Task<bool> PutProductByCode(Product product);
        Task<bool> DeleteProductByCode(long productCode);
    }
}
