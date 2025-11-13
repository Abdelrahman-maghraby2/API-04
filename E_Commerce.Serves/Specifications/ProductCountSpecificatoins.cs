using E_Commerce.Domain.Entites.ProductModule;
using E_Commerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Serves.Specifications
{
    public class ProductCountSpecificatoins:BaseSpecifications<Product,int>
    {
        public ProductCountSpecificatoins(ProductQueryParams queryParams)
            :base(P => (queryParams.brandId == null || P.BrandId == queryParams.brandId)
               && (queryParams.typeId == null || P.TypeId == queryParams.typeId)
               && (string.IsNullOrEmpty(queryParams.search) || P.Name.ToLower().Contains(queryParams.search.ToLower())))
        {
            
        }
    }
}
