using API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spp3.Data;
using spp3.Data.Models;
using System.Reflection.Metadata.Ecma335;

namespace spp3.Controllers
{
    [ApiController]
    [Route("sellers")]
    public class SellersController : Controller
    {
        private readonly ILogger<SellersController> _logger;
        private readonly ShopContext _shopContext;
        public SellersController(ILogger<SellersController> logger, ShopContext context)
        {
            _shopContext = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sellers = _shopContext.Sellers.Include(sel => sel.OutletSection).Include(sel => sel.Deals).ToList();
            return Ok(sellers);
        }

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetByPhone(string phoneNumber)
        {
            var seller = _shopContext.Sellers.Include(sel => sel.OutletSection).Include(sel => sel.Deals).FirstOrDefault(sel => sel.phoneNumber == phoneNumber);
            return Ok(seller);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Seller seller)
        {
            _shopContext.Sellers.Add(seller);
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{oldPhoneNumber}")]
        public async Task<IActionResult> Put(string oldPhoneNumber, Seller _seller)
        {
            var seller = _shopContext.Sellers.FirstOrDefault(sel => sel.phoneNumber == oldPhoneNumber);
            seller = _seller;
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{phoneNumber}")]
        public async Task<IActionResult> Delete(string phoneNumber)
        {
            var deletedSeller = _shopContext.Sellers.FirstOrDefault(sel => sel.phoneNumber == phoneNumber);
            _shopContext.Sellers.Remove(deletedSeller);
            _shopContext.SaveChanges();
            return Ok();
        }
    }
}
