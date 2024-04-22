using API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spp3.Data;
using spp3.Data.Models;
using System.Reflection.Metadata.Ecma335;

namespace spp3.Controllers
{
    [ApiController]
    [Route("sectionmanagers")]
    public class SectionManagersController : Controller
    {
        private readonly ILogger<SectionManagersController> _logger;
        private readonly ShopContext _shopContext;
        public SectionManagersController(ILogger<SectionManagersController> logger, ShopContext context)
        {
            _shopContext = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sectionManagers = _shopContext.SectionManagers.Include(sm => sm.OutletSection).ToList();
            return Ok(sectionManagers);
        }

        [HttpGet("{phoneNumber}")]
        public async Task<IActionResult> GetByPhone(string phoneNumber)
        {
            var sectionManager = _shopContext.SectionManagers.Include(sm => sm.OutletSection).FirstOrDefault(sm => sm.phoneNumber == phoneNumber);
            return Ok(sectionManager);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SectionManager sectionManager)
        {
            _shopContext.SectionManagers.Add(sectionManager);
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{oldPhoneNumber}")]
        public async Task<IActionResult> Put(string oldPhoneNumber, SectionManager _sectionManager)
        {
            var sectionManager = _shopContext.SectionManagers.FirstOrDefault(sm => sm.phoneNumber == oldPhoneNumber);
            sectionManager = _sectionManager;
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{phoneNumber}")]
        public async Task<IActionResult> Delete(string phoneNumber)
        {
            var deletedSectionManager = _shopContext.SectionManagers.FirstOrDefault(sm => sm.phoneNumber == phoneNumber);
            _shopContext.SectionManagers.Remove(deletedSectionManager);
            _shopContext.SaveChanges();
            return Ok();
        }
    }
}
