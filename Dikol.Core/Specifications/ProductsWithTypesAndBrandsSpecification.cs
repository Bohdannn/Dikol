using Dikol.Core.Entities;

namespace Dikol.Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(string sort, int? brandId, int? typeId)
            : base(criteria: p => 
                (!brandId.HasValue || p.ProductBrandId == brandId) &&
                (!typeId.HasValue || p.ProductTypeId == typeId)
            )
        {
            IncludeBrandsAndTypes();

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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
    }
}
