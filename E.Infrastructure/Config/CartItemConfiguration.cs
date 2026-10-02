using E.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.Infrastructure.Config
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Quantity)
                .IsRequired();
             

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
             "CK_CartItem_Quantity_Positive",
             "\"Quantity\" > 0");
            });

            builder.HasIndex(ci =>new
            {
                ci.CartId,
                ci.ProductId
            })
              .IsUnique()  ;

            builder.HasOne(ci =>ci.Cart)
                   .WithMany(c =>c.Items)
                   .HasForeignKey(ci =>ci.CartId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci =>ci.Product)
                   .WithMany()
                   .HasForeignKey(ci =>ci.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }

}
