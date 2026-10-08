using E.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
 
namespace E.Infrastructure.Config
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        { 
            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.ProductName)
                .IsRequired()
                .HasMaxLength(100);
             

            builder.Property(oi=> oi.Quantity)
                   .IsRequired();

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_OrderItem_Quantity_Positive",
                    "\"Quantity\" > 0");
            });

            builder.Property(oi => oi.UnitPrice)
                   .IsRequired()
                   .HasPrecision(18, 2);
             
            builder.Ignore(oi => oi.TotalPrice);

            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItems)
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade)
                   ;

            builder.HasOne(oi => oi.Product)
                   .WithMany()
                   .HasForeignKey(oi => oi.ProductId)
                   .OnDelete(DeleteBehavior.Restrict)
                   ;
        }
    
    
    }

}
