using Microsoft.AspNetCore.Mvc;

namespace DesafioAutoglass.Controllers.ProductManagement
{
    using DesafioAutoglass.Presenters.Interfaces;
    using DesafioAutoglass.Views.CreateProduct.Request;
    using DesafioAutoglass.Views.UpdateProduct.Request;

    [Route("v1/ProductManagement")]
    [ApiController]
    public class ProductManagementController : ControllerBase
    {
        private readonly IProductManagementPresenter _productManagementPresenter;


        public ProductManagementController(IProductManagementPresenter productManagementPresenter)
        {
            _productManagementPresenter = productManagementPresenter;
        }


        [HttpPost()]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDTO customerCurrentAccountRequest)
        {
            try
            {
                var productCode = await _productManagementPresenter.CreateProduct(customerCurrentAccountRequest);
                return Ok(productCode);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{productCode}")]
        public async Task<IActionResult> GetProductById(long productCode)
        {
            try
            {
                var product = await _productManagementPresenter.GetProductById(productCode);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllProduct([FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null)
        {
            try
            {
                var products = await _productManagementPresenter.GetAllProducts(pageNumber, pageSize);
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> PutProduct([FromBody] UpdateProductRequestDTO product) 
        {
            try
            {
                bool result = await _productManagementPresenter.PutProductByCode(product);
                return Ok(result);
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteProductByCode(long productCode)
        {
            try
            {
                bool result = await _productManagementPresenter.DeleteProductByCode(productCode);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
