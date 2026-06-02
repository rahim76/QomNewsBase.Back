using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Infrastructure.Configurations;
public class AdConfiguration : IEntityTypeConfiguration<Ad>
{
    public void Configure(EntityTypeBuilder<Ad> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(x => x.Thumbnail)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(x => x.TargetUrl)
            .HasMaxLength(1000)
            .IsRequired();

    }
}