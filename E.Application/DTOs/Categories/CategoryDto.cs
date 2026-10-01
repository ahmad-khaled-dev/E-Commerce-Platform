using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Application.DTOs.Categories
{
    public  sealed record CategoryDto
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }

        // ✅ عدد المنتجات في هذا التصنيف (مفيد للواجهة)
        public int ProductsCount { get; init; }
    }
}
