using Microsoft.AspNetCore.Mvc;

namespace DesafioAutoglass.Controllers.ProductManagement
{
    using DesafioAutoglass.Presenters.Interfaces;
    using DesafioAutoglass.Views.CreateProvider.Request;

    [Route("v1/ProviderManagement")]
    [ApiController]
    public class ProviderManagementController : ControllerBase
    {
        private readonly IProviderManagementPresenter _productManagementPresenter;


        public ProviderManagementController(IProviderManagementPresenter productManagementPresenter)
        {
            _productManagementPresenter = productManagementPresenter;
        }


        [HttpPost()]
        public async Task<IActionResult> CreateProvider([FromBody] CreateProviderRequestDTO providerDto)
        {
            try
            {
                var productCode = await _productManagementPresenter.CreateProvider(providerDto);
                return Ok(productCode);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
