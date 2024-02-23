using DesafioAutoglass.Controllers.ProductManagement;
using DesafioAutoglass.Presenters.Interfaces;
using DesafioAutoglass.Views.CreateProduct.Request;
using DesafioAutoglass.Views.UpdateProduct.Request;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace DesafioAutoglass.Test.ProductManagement
{
    public class ProductManagementTest
    {
        private readonly ProductManagementController _controller;
        private readonly Mock<IProductManagementPresenter> _mockPresenter;

        public ProductManagementTest()
        {
            _mockPresenter = new Mock<IProductManagementPresenter>();
            _controller = new ProductManagementController(_mockPresenter.Object);
        }

        //[Fact]
        //public async Task CreateProductTest()
        //{
        //    var productRequestDto = new CreateProductRequestDTO {
        //        Description = "sequences that are extremely painful. Nor again is th",
        //        Status = 1,
        //        ManufacturingDate = DateTimeOffset.Now,
        //        ExpirationDate = DateTimeOffset.Now.AddMonths(1),
        //        ProviderCode = 2
        //    };

        //    var result = await _controller.CreateProduct(productRequestDto);

        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    var productCode = Assert.IsType<long>(okResult.Value);
        //    Assert.NotEqual(0, productCode);
        //}

        [Fact]
        public async Task GetProductByIdTest()
        {
            long productCode = 2;
            var result = await _controller.GetProductById(productCode);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllProductTest()
        {
            var result = await _controller.GetAllProduct();

            Assert.NotNull(result);
        }

        //[Fact]
        //public async Task PutProductTest()
        //{
        //    var request = new UpdateProductRequestDTO { Code = 123, Description = "Test Product", Status = 1 };
        //    var result = await _controller.PutProduct(request);

        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    Assert.True((bool)okResult.Value!);
        //}

        //[Fact]
        //public async Task DeleteProductByCodeTest()
        //{
        //    long productCode = 123;
        //    var result = await _controller.DeleteProductByCode(productCode);

        //    var okResult = Assert.IsType<OkObjectResult>(result);
        //    Assert.True((bool)okResult.Value!);
        //}
    }
}
