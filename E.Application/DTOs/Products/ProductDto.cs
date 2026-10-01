using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Application.DTOs.Products
{
    public sealed record ProductDto
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }

        public required string CategoryName { get; init; }
        public int CategoryId { get; init; }

        public required string MainImageUrl { get; init; }

        public decimal Price { get; init; }
        public int DiscountPercentage { get; init; }

        // ✅ السعر النهائي بعد الخصم (محسوب)
        public decimal FinalPrice { get; init; }

        public int Stock { get; init; }

        public bool IsInStock { get; init; }
    }
}
