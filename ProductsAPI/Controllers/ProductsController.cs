using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Services;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService productService;

        public ProductsController()
        {
            this.productService = new ProductsService();
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(productService.GetProducts());
        }

        [HttpGet("{id}")]
        public IActionResult GetProducts(string id)
        {
            return Ok(productService.GetProduct(id));
        }
    }
}
