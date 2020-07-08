using Dikol.Core.Entities;
using Dikol.Core.Specifications.Params;

namespace Dikol.Core.Specifications.ProductSpecifications
{
    public class ProductsWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductsWithFiltersForCountSpecification(ProductSpecificationParams productsParams)
            : base(criteria: p =>
                (string.IsNullOrEmpty(productsParams.Search) || p.Name.ToLower().Contains(productsParams.Search)) &&
                (!productsParams.BrandId.HasValue || p.ProductBrandId == productsParams.BrandId) &&
                (!productsParams.TypeId.HasValue || p.ProductTypeId == productsParams.TypeId)
            )
        {

        }
    }
}
