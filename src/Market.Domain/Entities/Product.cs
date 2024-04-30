using Market.Domain.Common;

namespace Market.Domain.Entities
{
    public class Product : BaseEntity
    {
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
