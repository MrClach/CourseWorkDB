using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using spp3.Data;
using spp3.Data.Models;

namespace spp3.Controllers
{
    [ApiController]
    [Route("producttypes")]
    public class ProductTypesController : Controller
    {
        private readonly ShopContext _shopContext;
        private readonly ILogger<ProductTypesController> _logger;

        public ProductTypesController(ILogger<ProductTypesController> logger, ShopContext shopContext)
        {
            _shopContext = shopContext;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productTypes = _shopContext.ProductTypes.Include(pt => pt.Products).ToList();
            return Ok(productTypes);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var productType = _shopContext.ProductTypes.Include(pt => pt.Products).FirstOrDefault(pt => pt.name == name);
            return Ok(productType);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string name, int ageLimit)
        {
            var productType = new ProductType();
            productType.name = name;
            productType.ageLimit = ageLimit;
            _shopContext.ProductTypes.Add(productType);
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{oldName}")]
        public async Task<IActionResult> Put(string oldName, ProductType _productType)
        {
            var productType = _shopContext.ProductTypes.FirstOrDefault(pt => pt.name == oldName);
            //productType.name = newName;
            //productType.ageLimit = newAgeLimit;
            productType = _productType;
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var productType = _shopContext.ProductTypes.FirstOrDefault(pt => pt.name == name);
            _shopContext.ProductTypes.Remove(productType);
            _shopContext.SaveChanges();
            return Ok();
        }

    }
}
