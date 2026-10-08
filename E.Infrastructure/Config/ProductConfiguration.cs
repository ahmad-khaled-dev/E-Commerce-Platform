using E.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;




namespace E.Infrastructure.config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasOne(p => p.Category)
                   .WithMany()
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict)
                   ;

            builder.HasOne(p => p.Brand)
                     .WithMany()
                     .HasForeignKey(p => p.BrandId)
                     .OnDelete(DeleteBehavior.Restrict)
                     ;

            builder.Property(p => p.Price)
                .HasPrecision(18, 2);


            builder.Property(p => p.Specifications)
                   .HasColumnType("jsonb");




            builder.Navigation(p => p.Images)
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                  ;

        }

    }

}
