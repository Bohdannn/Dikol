using Dikol.Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dikol.Infrastructure.DbSeeder
{
    public class DikolDbSeeder
    {
        public static async Task SeedAsync(DikolDbContext dikolDbContext)
        {
            #region Code smell

            if (!dikolDbContext.ProductTypes.Any())
            {
                var productTypesData = File.ReadAllText("../Dikol.Infrastructure/DbSeeder/Data/product-types.json");

                var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypesData);

                foreach (var productType in productTypes)
                {
                    dikolDbContext.ProductTypes.Add(productType);
                }
            }

            // TODO: Make it generic
            if (!dikolDbContext.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Dikol.Infrastructure/DbSeeder/Data/product-brands.json");

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                foreach (var brand in brands)
                {
                    dikolDbContext.ProductBrands.Add(brand);
                }
            }

            if (!dikolDbContext.Products.Any())
            {
                var productsData = File.ReadAllText("../Dikol.Infrastructure/DbSeeder/Data/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                foreach (var product in products)
                {
                    dikolDbContext.Products.Add(product);
                }
            }

            await dikolDbContext.SaveChangesAsync();
            #endregion
        }
    }
}
