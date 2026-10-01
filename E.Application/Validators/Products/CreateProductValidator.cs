using E.Application.DTOs.Products;
using FluentValidation;

namespace E.Application.Validators.Products
{
    public class CreateProductValidator : ProductBaseValidator<CreateProductDto>
    {
        public CreateProductValidator() : base()
        {
             
        }
    }
}