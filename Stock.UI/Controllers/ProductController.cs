using Microsoft.AspNetCore.Mvc;
using Stock.Application.Contracts;
using Stock.Application.Service.Interfaces;

namespace Stock.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public ProductController(IServiceManager service)
        {
            serviceManager = service;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            var products = await serviceManager.ProductService.GetAllAsync(cancellationToken);

            return Ok(products);
        }
    }
}
