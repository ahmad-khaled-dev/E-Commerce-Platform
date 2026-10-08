using E.Domain.Entites;
using E.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace E.Infrastructure.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        { 
            builder.HasKey(o => o.Id);

            builder.Property(o => o.UserId).IsRequired();

            builder.Property(o => o.Status).IsRequired()
             ;


            builder.Property(o => o.TotalAmount)
                .IsRequired()
                .HasPrecision(18,2);
             



            builder.HasOne<ApplicationUser>()
                   .WithMany()
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.Navigation(o => o.OrderItems)
                .UsePropertyAccessMode(PropertyAccessMode.Field)
                ;
        }
 
    }

}
