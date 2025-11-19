using E_Commerce.Domain.Entites.ProductModule;
using E_Commerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Serves.Specifications
{
    public static class ProductSpecificationHelper
    {
        public static Expression<Func<Product, bool>> GetProductCriteria(ProductQueryParams queryParams)
        {
            return P => (queryParams.brandId == null || P.BrandId == queryParams.brandId)
               && (queryParams.typeId == null || P.TypeId == queryParams.typeId)
               && (string.IsNullOrEmpty(queryParams.search) || P.Name.ToLower().Contains(queryParams.search.ToLower()));
        }
    }
}
