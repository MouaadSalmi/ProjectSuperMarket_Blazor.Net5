using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SuperMarket.Core
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        //ef relations
        public List<Product> Products { get; set; }
    }
}
