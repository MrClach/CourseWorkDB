using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spp3.Data;
using spp3.Data.Models;
using System.Reflection.Metadata.Ecma335;

namespace spp3.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : Controller
    {   
        private readonly ILogger<CustomerController> _logger;
        private readonly ShopContext _shopContext;
        public CustomerController(ILogger<CustomerController> logger, ShopContext context)
        {
            _shopContext = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = _shopContext.Customers.Include(cu => cu.BonusCard).Include(pr => pr.Deals).ToList();
            return Ok(customers);
        }

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetByPhone(string phoneNumber)
        {
            var customer = _shopContext.Customers.Include(cu => cu.BonusCard).Include(pr => pr.Deals).FirstOrDefault(cu => cu.phoneNumber == phoneNumber);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            _shopContext.Customers.Add(customer);
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{oldPhoneNumber}")]
        public async Task<IActionResult> Put(string oldPhoneNumber, Customer _customer)
        {
            var customer = _shopContext.Customers.FirstOrDefault(cu => cu.phoneNumber == oldPhoneNumber);
            customer = _customer;
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{phoneNumber}")]
        public async Task<IActionResult> Delete(string phoneNumber)
        {
            var deletedCustomer = _shopContext.Customers.FirstOrDefault(cu => cu.phoneNumber == phoneNumber);
            _shopContext.Customers.Remove(deletedCustomer);
            _shopContext.SaveChanges();
            return Ok();
        }
    }
}
