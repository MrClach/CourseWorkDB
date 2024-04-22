using API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spp3.Data;
using spp3.Data.Models;
using System.Reflection.Metadata.Ecma335;

namespace spp3.Controllers
{
    [ApiController]
    [Route("tradeoutlets")]
    public class TradeOutletsController : Controller
    {
        private readonly ILogger<TradeOutletsController> _logger;
        private readonly ShopContext _shopContext;
        public TradeOutletsController(ILogger<TradeOutletsController> logger, ShopContext context)
        {
            _shopContext = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tradeOulet = _shopContext.TradeOutlets.Include(to => to.OutletSections).ToList();
            return Ok(tradeOulet);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var comOrg = _shopContext.TradeOutlets.Include(to => to.OutletSections).FirstOrDefault(to => to.outletName == name);
            return Ok(comOrg);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TradeOutlet tradeOutlet)
        {
            _shopContext.TradeOutlets.Add(tradeOutlet);
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{oldName}")]
        public async Task<IActionResult> Put(string oldName, TradeOutlet _tradeOutlet)
        {
            var tradeOutlet = _shopContext.TradeOutlets.FirstOrDefault(to => to.outletName == oldName);
            tradeOutlet = _tradeOutlet;
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var deletedTradeOutlet = _shopContext.TradeOutlets.FirstOrDefault(to => to.outletName == name);
            _shopContext.TradeOutlets.Remove(deletedTradeOutlet);
            _shopContext.SaveChanges();
            return Ok();
        }
    }
}
