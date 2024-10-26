using Microsoft.AspNetCore.Mvc;
using ProductsApi.BusinessLogic.Interfaces;

namespace ProductsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductLogic _productLogic;
        public ProductsController(ILogger<ProductsController> logger, IProductLogic productLogic)
        {
            _logger = logger;
            _productLogic = productLogic;
        }
        [HttpGet("AllProducts")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _productLogic.GetAsync(HttpContext.RequestAborted);
                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error Whule getting products details, Exception {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
