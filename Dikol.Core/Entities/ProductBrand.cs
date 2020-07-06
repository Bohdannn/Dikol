namespace Dikol.Core.Entities
{
    public class ProductBrand : BaseEntity
    {
        public string Name { get; set; }

        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
    }
}