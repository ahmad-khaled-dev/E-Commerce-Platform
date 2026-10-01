using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Application.DTOs.Products
{
    public interface IProductDto
    {
        string Name { get; set; }
        string? Description { get; set; }
        int CategoryId { get; set; }
        List<string> ImageUrls { get; set; }
        decimal Price { get; set; }
        int DiscountPercentage { get; set; }
        string SpecificationsJson { get; set; }
        int Stock { get; set; }
    }
}
