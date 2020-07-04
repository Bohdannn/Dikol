using Dikol.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Dikol.Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            IncludeBrandsAndTypes();
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
