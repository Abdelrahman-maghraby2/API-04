using E_Commerce.Serves_Abstraction;
using E_Commerce.Shared.DTOs.BasketDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Presention.Contrallers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketServes _basketServes;

        public BasketController(IBasketServes basketServes)
        {
           _basketServes = basketServes;
        }

        [HttpGet]
        public async Task<ActionResult<BasketDTO>> GetBaket(string id)
        {
            var Basket =await _basketServes.GetBasketAsync(id);
            return Ok(Basket);
        
        }

        [HttpPost]
        public async Task<ActionResult<BasketDTO>> CreateOrUpdateBasket(BasketDTO basket)
        {
            var Basket = await _basketServes.CreateOrUpdateBasketAsync(basket);
            return Ok(Basket);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBasket(string id)
        { 
            var Result = await _basketServes.DeleteBasketAsync(id);
            return Ok(Result);
        }
    }
}
