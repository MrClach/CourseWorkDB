using API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spp3.Data;
using spp3.Data.Models;
using System.Reflection.Metadata.Ecma335;

namespace spp3.Controllers
{
    [ApiController]
    [Route("commercialorganizations")]
    public class CommercialOrganizationsController : Controller
    {
        private readonly ILogger<CommercialOrganizationsController> _logger;
        private readonly ShopContext _shopContext;
        public CommercialOrganizationsController(ILogger<CommercialOrganizationsController> logger, ShopContext context)
        {
            _shopContext = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var comOrgs = _shopContext.CommercialOrganizations.Include(co => co.TradeOutlets).ToList();
            return Ok(comOrgs);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var comOrg = _shopContext.CommercialOrganizations.Include(cu => cu.TradeOutlets).FirstOrDefault(co => co.organizationName == name);
            return Ok(comOrg);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CommercialOrganization comOrg)
        {
            _shopContext.CommercialOrganizations.Add(comOrg);
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{oldName}")]
        public async Task<IActionResult> Put(string oldName, CommercialOrganization _comOrg)
        {
            var comOrg = _shopContext.CommercialOrganizations.FirstOrDefault(co => co.organizationName == oldName);
            comOrg = _comOrg;
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var deletedComOrg = _shopContext.CommercialOrganizations.FirstOrDefault(co => co.organizationName == name);
            _shopContext.CommercialOrganizations.Remove(deletedComOrg);
            _shopContext.SaveChanges();
            return Ok();
        }
    }
}
