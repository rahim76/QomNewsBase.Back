using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Infrastructure.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.CommentBody)
            .IsRequired(true);

        builder.HasOne(a => a.News)
            .WithMany(a => a.Comments)
            .HasForeignKey(a => a.NewsId)
            .IsRequired(true);


    }
}