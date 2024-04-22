using API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spp3.Data;
using spp3.Data.Models;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace spp3.Controllers
{
    [ApiController]
    [Route("supplier")]
    public class SupplierController : Controller
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly ShopContext _shopContext;
        public SupplierController(ILogger<SupplierController> logger, ShopContext context)
        {
            _shopContext = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var suppliers = _shopContext.Suppliers.Include(su => su.Orders).ToList();
            return Ok(suppliers);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var supplier = _shopContext.Suppliers.Include(su => su.Orders).FirstOrDefault(su => su.supplierName == name);
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Supplier supplier)
        {
            _shopContext.Suppliers.Add(supplier);
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{oldName}")]
        public async Task<IActionResult> Put(string oldName, Supplier _supplier)
        {
            var supplier = _shopContext.Suppliers.FirstOrDefault(su => su.supplierName == oldName);
            supplier = _supplier;
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var deletedSupplier = _shopContext.Suppliers.FirstOrDefault(su => su.supplierName == name);
            _shopContext.Suppliers.Remove(deletedSupplier);
            _shopContext.SaveChanges();
            return Ok();
        }
    }
}
