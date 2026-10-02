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
    public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {

            builder.HasKey(i => i.ProductId);


            builder.HasOne(i => i.Product)
                .WithOne(p => p.Inventory)
                .HasForeignKey<Inventory>(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(i => i.Quantity)
                .IsRequired()
                ;

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Inventory_Quantity_NonNegative",
                    "Quantity >= 0");
                 
            });
        }
    }

}
