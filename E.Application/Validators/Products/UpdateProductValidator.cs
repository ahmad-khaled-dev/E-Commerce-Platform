using E.Application.DTOs.Products;
using FluentValidation;

namespace E.Application.Validators.Products
{
    public class UpdateProductValidator : ProductBaseValidator<UpdateProductDto>
    {
        public UpdateProductValidator() : base()
        {
            // نضيف فقط القواعد الخاصة بـ Update
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("معرف المنتج غير صحيح");
        }
    }
}