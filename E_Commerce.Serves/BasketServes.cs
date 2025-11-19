using AutoMapper;
using E_Commerce.Domain.Contract;
using E_Commerce.Domain.Entites.BasketModule;
using E_Commerce.Serves_Abstraction;
using E_Commerce.Shared.DTOs.BasketDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Serves
{
    public class BasketServes : IBasketServes
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketServes(IBasketRepository basketRepository, IMapper mapper)
        {
           _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public async Task<BasketDTO> CreateOrUpdateBasketAsync(BasketDTO basket)
        {
           var CustomerBasket = _mapper.Map<CustomerBasket>(basket);
            var CreateOrUpdateBasket = await _basketRepository.CreateOrUpdateBasketAsync(CustomerBasket);
            return _mapper.Map<BasketDTO>(CreateOrUpdateBasket);
        }

        public async Task<bool> DeleteBasketAsync(string id)=> await _basketRepository.DeleteBasketAsync(id);

        public async Task<BasketDTO> GetBasketAsync(string id)
        {
            var Basket = await _basketRepository.GetBasketAsync(id);
            return _mapper.Map<BasketDTO>(Basket);
        }
    }
}
