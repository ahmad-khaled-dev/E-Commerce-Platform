using E.Domain.Common;
using E.Domain.Entites;

namespace E.Domain.Entities
{
     
    public class Category : BaseEntity
    {
         
        public string Name { get; private set; } = null!;


       

        public string? Description { get; private set; }

        public int? ParentId { get; private set; }

        public string? ImageUrl { get; private set; }

        public Category? ParentCategory { get; private set; }

        public ICollection<Category> SubCategories { get; private set; }
            = new List<Category>();
         
        public ICollection<Product> Products { get; private set; }
            = new List<Product>();

        private Category()
        {
        }

        public Category(
          string name,
          string? description = null,
          string? imageUrl = null,
          int? parentId = null)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Category name is required.",
                    nameof(name));

            Name = name;
            Description = description?.Trim();
            ImageUrl = imageUrl?.Trim();
            ParentId = parentId;
        }


        public void changeDescription(string description)
        {
          
            Description = description?.Trim();
            UpdatedAt = DateTime.UtcNow;
        }

        public void Rename(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(
                    "Category name is required.",
                    nameof(name));

            Name = name.Trim();
            UpdatedAt = DateTime.UtcNow;
        }

        public void ChangeImage(string? imageUrl)
        {
            ImageUrl = imageUrl?.Trim();
            UpdatedAt = DateTime.UtcNow;
        }

        public void MoveToParent(int? parentId)
        {
            if (parentId == Id)
                throw new InvalidOperationException(
                    "A category cannot be its own parent.");

            ParentId = parentId;
            UpdatedAt = DateTime.UtcNow;
        }

    }


}