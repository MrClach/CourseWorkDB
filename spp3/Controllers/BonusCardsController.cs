using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spp3.Data;
using spp3.Data.Models;

namespace spp3.Controllers
{
    [ApiController]
    [Route("bonuscards")]
    public class BonusCardsController : ControllerBase
    {
        private readonly ILogger<BonusCardsController> _logger;
        private readonly ShopContext _shopContext;
        public BonusCardsController(ILogger<BonusCardsController> logger, ShopContext context)
        {
            _shopContext = context;
            _logger = logger;
        }

        [HttpGet]   
        public async Task<IActionResult> Get()
        {
            var list = _shopContext.BonusCards.Include(bc => bc.Customer).ToList();

            return Ok(list);
        }


        [HttpGet("{number}")]
        public async Task<IActionResult> GetByNumber(string number)
        {
            var bonusCard = _shopContext.BonusCards.Include(bc => bc.Customer).FirstOrDefault(bc => bc.number == number);
            return Ok(bonusCard);
        }

        [HttpPost("{phoneNumber}")]
        public async Task<IActionResult> Post(float discount, string phoneNumber)
        {
            var bonusCard = new BonusCard();
            bonusCard.discount = discount;

            var customer = _shopContext.Customers.FirstOrDefault(cu => cu.phoneNumber == phoneNumber);

            bonusCard.Customer = customer;
            _shopContext.BonusCards.Add(bonusCard);
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{oldNumber}")]
        public async Task<IActionResult> Put(string oldNumber, BonusCard _bonusCard)
        {
            var bonusCard = _shopContext.BonusCards.FirstOrDefault(bc => bc.number == oldNumber);
            //bonusCard.number = _bonusCard.number;
            //bonusCard.discount = _bonusCard.discount;
            
            //bonusCard.Customer = _bonusCard.Customer;
            bonusCard = _bonusCard;
            _shopContext.SaveChanges();
            return Ok();
        }

        [HttpDelete("{number}")]
        public async Task<IActionResult> Delete(string number)
        {
            var deletedBonusCard = _shopContext.BonusCards.FirstOrDefault(bc => bc.number == number);
            _shopContext.BonusCards.Remove(deletedBonusCard);
            _shopContext.SaveChanges();
            return Ok();
        }

    }
}
