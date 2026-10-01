using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E.Application.DTOs.Products
{
    public sealed record ProductDetailsDto
    { 
        // ✅ DTO كامل لصفحة تفاصيل المنتج
             public int Id { get; init; }
            public required string Name { get; init; }
            public string? Description { get; init; }

            public required string CategoryName { get; init; }
            public int CategoryId { get; init; }

            // ✅ جميع الصور (لمعرض الصور)
            public IReadOnlyList<string> ImageUrls { get; init; } = Array.Empty<string>();

            public decimal Price { get; init; }
            public int DiscountPercentage { get; init; }
            public decimal FinalPrice { get; init; }

            // ✅ المواصفات التقنية (JsonElement)
            public JsonElement Specifications { get; init; }

            public int Stock { get; init; }
            public bool IsInStock { get; init; }
         
    }
 
}
