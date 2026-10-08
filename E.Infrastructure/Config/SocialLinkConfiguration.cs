
using E.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E.Infrastructure.Config
{
    public class SocialLinkConfiguration : IEntityTypeConfiguration<SocialLink>
    {
        public void Configure(EntityTypeBuilder<SocialLink> builder)
        {
            builder.HasKey(sl => sl.Id);

            builder.Property(sl => sl.Platform)
                .IsRequired();

            builder.Property(sl => sl.Url)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(sl => sl.DisplayOrder)
                .IsRequired();

            builder.Property(sl => sl.IsActive)
                .IsRequired();

              builder.ToTable(t =>
        {
            t.HasCheckConstraint(
                "CK_SocialLink_DisplayOrder_NonNegative",
                "\"DisplayOrder\" >= 0");
        });
        }
    }
}
