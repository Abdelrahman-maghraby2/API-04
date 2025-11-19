using E_Commerce.Shared.DTOs.BasketDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Serves_Abstraction
{
    public  interface IBasketServes
    {
        Task<BasketDTO> GetBasketAsync(string id);

        Task<BasketDTO> CreateOrUpdateBasketAsync(BasketDTO basket);

        Task<bool>DeleteBasketAsync(string id);
    }
}
