namespace DesafioAutoglass.Presenters.Interfaces
{
    using DesafioAutoglass.Core.Domain.Entities.Products;
    using DesafioAutoglass.Views.CreateProduct.Request;
    using DesafioAutoglass.Views.UpdateProduct.Request;

    public interface IProductManagementPresenter
    {
        Task<long> CreateProduct(CreateProductRequestDTO productDto);
        Task<Product> GetProductById(long productCode);
        //Task<Product[]> GetAllProducts();
        Task<Product[]> GetAllProducts(int? pageNumber = null, int? pageSize = null);
        Task<bool> PutProductByCode(UpdateProductRequestDTO product);
        Task<bool> DeleteProductByCode(long productCode);
    }
}
