using Dikol.Core.Entities;
using Dikol.Core.Specifications.Params;

namespace Dikol.Core.Specifications.ProductSpecifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecificationParams productsParams)
            : base(criteria: p => 
                (string.IsNullOrEmpty(productsParams.Search) || p.Name.ToLower().Contains(productsParams.Search)) &&
                (!productsParams.BrandId.HasValue || p.ProductBrandId == productsParams.BrandId) &&
                (!productsParams.TypeId.HasValue || p.ProductTypeId == productsParams.TypeId)
            )
        {
            IncludeBrandsAndTypes();
            ApplyPaging(CalculateSkip(productsParams.PageSize, productsParams.PageIndex), productsParams.PageSize);

            if (!string.IsNullOrEmpty(productsParams.SortBy))
            {
                switch (productsParams.SortBy)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(p => p.Name);
                        break;
                }
            }
            else
            {
                AddOrderBy(p => p.Name);
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int productId) : base(criteria: p => p.Id == productId)
        {
            IncludeBrandsAndTypes();
        }

        private void IncludeBrandsAndTypes()
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }

        private int CalculateSkip(int pageSize, int pageIndex) => pageSize * (pageIndex - 1);
    }
}
