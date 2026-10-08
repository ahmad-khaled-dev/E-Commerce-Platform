using E.Domain.Entites;
using E.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E.Infrastructure.Config
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.UserId)
                .IsRequired();


            builder.HasIndex(c => c.UserId)
                .IsUnique();

            builder.HasOne<ApplicationUser>()
                   .WithOne()
                   .HasForeignKey<Cart>(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);


            builder.Navigation(c => c.Items)
                   .UsePropertyAccessMode(PropertyAccessMode.Field)
                 ;
        }
         
    }

}
