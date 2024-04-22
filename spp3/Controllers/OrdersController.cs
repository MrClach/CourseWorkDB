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
    [Route("orders")]
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly ShopContext _shopContext;
        public OrdersController(ILogger<OrdersController> logger, ShopContext context)
        {
            _shopContext = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var orders = _shopContext.Orders.Include(or => or.Products).Include(or => or.Suppliers).ToList();
            return Ok(orders);
        }

        [HttpGet("{orId}")]
        public async Task<IActionResult> GetByPhone(int orId)
        {
            var order = _shopContext.Orders.Include(or => or.Products).Include(or => or.Suppliers).FirstOrDefault(or => or.orId == orId);
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order order)
        {
            _shopContext.Orders.Add(order);
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{orId}")]
        public async Task<IActionResult> Put(int orId, Order _order)
        {
            var order = _shopContext.Orders.FirstOrDefault(or => or.orId == orId);
            order = _order;
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{orId}")]
        public async Task<IActionResult> Delete(int orId)
        {
            var deletedOrder = _shopContext.Orders.FirstOrDefault(or => or.orId == orId);
            _shopContext.Orders.Remove(deletedOrder);
            _shopContext.SaveChanges();
            return Ok();
        }
    }
}
