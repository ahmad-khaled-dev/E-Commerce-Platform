using E.Application.DTOs.Products;
using FluentValidation;

namespace E.Application.Validators.Products
{
    // ✅ Base Validator يحتوي على القواعد المشتركة
    public abstract class ProductBaseValidator<T> : AbstractValidator<T>
        where T : IProductDto // سننشئ هذا الـ Interface
    {
        protected ProductBaseValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("اسم المنتج مطلوب")
                .MaximumLength(200).WithMessage("اسم المنتج يجب ألا يتجاوز 200 حرف")
                .MinimumLength(3).WithMessage("اسم المنتج يجب ألا يقل عن 3 أحرف");

            RuleFor(x => x.Description)
                .MaximumLength(2000).WithMessage("الوصف يجب ألا يتجاوز 2000 حرف")
                .When(x => !string.IsNullOrEmpty(x.Description));

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("يجب اختيار تصنيف صحيح");

            RuleFor(x => x.ImageUrls)
                .NotEmpty().WithMessage("يجب إضافة صورة واحدة على الأقل")
                .Must(urls => urls.Count <= 10).WithMessage("لا يمكن إضافة أكثر من 10 صور");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("السعر يجب أن يكون أكبر من 0");

            RuleFor(x => x.DiscountPercentage)
                .InclusiveBetween(0, 100).WithMessage("نسبة الخصم يجب أن تكون بين 0 و 100");

            RuleFor(x => x.SpecificationsJson)
                .Must(BeValidJson).WithMessage("المواصفات يجب أن تكون بصيغة JSON صحيحة");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("المخزون يجب أن يكون أكبر من أو يساوي 0");
        }

        protected bool BeValidJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return true;

            try
            {
                System.Text.Json.JsonDocument.Parse(json);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    // ✅ Interface مشترك بين CreateProductDto و UpdateProductDto
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