using Dikol.Core.Entities;
using Dikol.Core.Specifications.Params;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dikol.Core.Specifications.ProductSpecifications
{
    public class ProductsWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductsWithFiltersForCountSpecification(ProductSpecificationParams productsParams)
            : base(criteria: p =>
                (!productsParams.BrandId.HasValue || p.ProductBrandId == productsParams.BrandId) &&
                (!productsParams.TypeId.HasValue || p.ProductTypeId == productsParams.TypeId)
            )
        {

        }
    }
}
