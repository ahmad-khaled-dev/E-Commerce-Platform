using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Application.DTOs.Categories
{
    public sealed record CategoryWithChildrenDto
    {
        public int Id { get; init; }
        public required string Name { get; init; }
        public string? Description { get; init; }
        public int ProductsCount { get; init; }

        // ✅ التصنيفات الفرعية (Recursive)
        public IReadOnlyList<CategoryWithChildrenDto> SubCategories { get; init; }
            = Array.Empty<CategoryWithChildrenDto>();
    }
}
