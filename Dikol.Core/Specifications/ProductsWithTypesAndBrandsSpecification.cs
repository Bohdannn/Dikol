using Dikol.Core.Entities;

namespace Dikol.Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(string sort)
        {
            IncludeBrandsAndTypes();

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "proceAsc":
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
        }

        public ProductsWithTypesAndBrandsSpecification(int productId) : base(p => p.Id == productId)
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
