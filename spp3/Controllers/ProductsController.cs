using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spp3.Data;
using spp3.Data.Models;

namespace spp3.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _shopContext;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ShopContext shopCondext, ILogger<ProductsController> logger)
        {
            _shopContext = shopCondext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = _shopContext.Products.Include(pr => pr.ProductType).Include(pr => pr.Deals).ToList();
            return Ok(products);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var product = _shopContext.Products.Include(pr => pr.ProductType).Include(pr => pr.Deals).FirstOrDefault(pr => pr.name == name);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            _shopContext.Products.Add(product);
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{oldName}")]
        public async Task<IActionResult> Put(string oldName, Product _product)
        {
            var product = _shopContext.Products.FirstOrDefault(pr => pr.name == oldName);
            product = _product;
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var product = _shopContext.Products.FirstOrDefault(pr => pr.name == name);
            _shopContext.Products.Remove(product);
            _shopContext.SaveChanges();
            return Ok();
        }
    }
}
