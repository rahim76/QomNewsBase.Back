using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Infrastructure.Configurations;

public class NewsConfiguration : IEntityTypeConfiguration<News>
{
    public void Configure(EntityTypeBuilder<News> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title)
            .HasMaxLength(150)
            .IsRequired(true);

        builder.Property(a=>a.Description)
            .IsRequired(true);

        builder.Property(a => a.Thumbnail)
            .HasMaxLength(500)
            .IsRequired(false);

        builder.HasOne(a => a.NewsGroup)
            .WithMany(a => a.News)
            .HasForeignKey(a => a.NewsGroupId)
            .IsRequired(true);

    }
}