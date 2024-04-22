using API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spp3.Data;
using spp3.Data.Models;
using System.Reflection.Metadata.Ecma335;

namespace spp3.Controllers
{
    [ApiController]
    [Route("outletsections")]
    public class OutletSectionsController : Controller
    {
        private readonly ILogger<OutletSectionsController> _logger;
        private readonly ShopContext _shopContext;
        public OutletSectionsController(ILogger<OutletSectionsController> logger, ShopContext context)
        {
            _shopContext = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var outletSections = _shopContext.OutletSections.Include(os => os.TradeOutlet).Include(os => os.SectionManager).Include(os => os.Sellers).ToList();
            return Ok(outletSections);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var outletSection = _shopContext.OutletSections.Include(os => os.TradeOutlet).Include(os => os.SectionManager).Include(os => os.Sellers).FirstOrDefault(os => os.sectionName == name);
            return Ok(outletSection);
        }

        [HttpPost]
        public async Task<IActionResult> Post(OutletSection outletSection)
        {
            _shopContext.OutletSections.Add(outletSection);
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{oldName}")]
        public async Task<IActionResult> Put(string oldName, OutletSection _outletSection)
        {
            var outletSection = _shopContext.OutletSections.FirstOrDefault(os => os.sectionName == oldName);
            outletSection = _outletSection;
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var deletedOutletSection = _shopContext.OutletSections.FirstOrDefault(os => os.sectionName == name);
            _shopContext.OutletSections.Remove(deletedOutletSection);
            _shopContext.SaveChanges();
            return Ok();
        }
    }
}
