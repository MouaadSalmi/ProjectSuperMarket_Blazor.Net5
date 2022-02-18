using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Core
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public double? Price { get; set; }

        public Category Category { get; set; }
    }
}
