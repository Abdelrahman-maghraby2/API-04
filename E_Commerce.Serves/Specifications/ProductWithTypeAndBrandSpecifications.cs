using E_Commerce.Domain.Contract;
using E_Commerce.Domain.Entites.ProductModule;
using E_Commerce.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Serves.Specifications
{
    public class ProductWithTypeAndBrandSpecifications : BaseSpecifications<Product, int>
    {
        public ProductWithTypeAndBrandSpecifications(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
        public ProductWithTypeAndBrandSpecifications(ProductQueryParams queryParams)
            : base(P => (queryParams.brandId == null || P.BrandId == queryParams.brandId)
               && (queryParams.typeId == null || P.TypeId == queryParams.typeId)
               && (string.IsNullOrEmpty(queryParams.search) || P.Name.ToLower().Contains(queryParams.search.ToLower())))
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);

            switch (queryParams.Sort)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrederBy(p => p.Name);
                    break;

                case ProductSortingOptions.NameDesc:
                    AddOrederByDescending(p => p.Name);
                    break;


                case ProductSortingOptions.PriceAsc:
                    AddOrederBy(p => p.Name);
                    break;

                case ProductSortingOptions.PriceDesc:
                    AddOrederByDescending(p => p.Name);
                    break;

                default:
                    AddOrederBy(p => p.Id);
                    break;
            }

            ApplyPagination(queryParams.PageSize, queryParams.PageIndex);
        }
    }
}
