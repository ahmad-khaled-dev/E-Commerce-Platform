
using E.Domain.Common;
using E.Domain.Entities;
using System.ComponentModel.Design;
using System.Text.Json;

namespace E.Domain.Entites
{

    public class Product :BaseEntity
    {
         
        public string Name { get; private set; } = null!;

        public string? Description { get; private set; }

        public decimal Price { get; private set; }

        public int CategoryId { get; private set; }

        public Category Category { get; private set; } = null!;

         
        public Inventory Inventory { get; private set; } = null!;

        public bool IsAvailable { get; private set; }  

        public int BrandId { get; private set; }

        public Brand Brand { get; private set; } = null!;


        private List<ProductImage> _images = new();

        public IReadOnlyCollection<ProductImage> Images => _images.AsReadOnly();
         

        //public ICollection<CartItem> CartItems { get; private set; }
        //    = new List<CartItem>();

        public Dictionary<string, string>
            Specifications { get; private set; }
            = new();

        private Product()
        {
        }

        public Product(
            string name,
            decimal price,
            int categoryId,
            int brandId,
            string? description = null
            )
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required.");

            if (price <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            Name = name;
            Price = price;
            CategoryId = categoryId;
            BrandId = brandId;
            Description = description;
            IsAvailable = true;
        }

        public void ChangePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            Price = newPrice;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Disable()
        {
            IsAvailable = false;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Enable()
        {
            IsAvailable = true;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddImage(string imageUrl, bool isMain = false)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
                throw new ArgumentException("Image URL is required.");


            if (isMain)
            {
                foreach (var img in Images)
                    img.RemoveAsMain();
            }

            var image = new ProductImage(imageUrl, isMain);
          
            
            _images.Add(image);
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetMainImage(int imageId)
        {
            var image = Images.FirstOrDefault(i => i.Id == imageId);

            if(image == null)
                throw new ArgumentException("Image not found.");

            foreach (var item in Images)
                item.RemoveAsMain();

            image.SetAsMain();
            UpdatedAt = DateTime.UtcNow;
        }


        public void RemoveImage(int imageId)
        {
            var image = Images.FirstOrDefault(i => i.Id == imageId);

            if (image == null)
                throw new ArgumentException("Image not found.");

            _images.Remove(image);

            UpdatedAt = DateTime.UtcNow;
        }
    }

}