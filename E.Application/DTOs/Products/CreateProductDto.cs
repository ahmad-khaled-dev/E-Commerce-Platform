using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Application.DTOs.Products
{
    public sealed record CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
         
        public string? Description { get; set; }

         public int CategoryId { get; set; }

         public List<string> ImageUrls { get; set; } = new();

        public decimal Price { get; set; }

        public int DiscountPercentage { get; set; } = 0;
         
        public string SpecificationsJson { get; set; } = "{}";

        public int Stock { get; set; } = 0;
    }
}
