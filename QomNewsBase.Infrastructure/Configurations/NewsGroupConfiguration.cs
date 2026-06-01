using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Infrastructure.Configurations;
public class NewsGroupConfiguration : IEntityTypeConfiguration<NewsGroup>
{
    public void Configure(EntityTypeBuilder<NewsGroup> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title)
           .HasMaxLength(150)
           .IsRequired(true);

    }
}