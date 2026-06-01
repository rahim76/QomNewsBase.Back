using Microsoft.EntityFrameworkCore;
using QomNewsBase.Domain.Entities;

namespace QomNewsBase.Infrastructure.Contexts;

public class QomNewsBaseContext : DbContext
{
    public QomNewsBaseContext(DbContextOptions<QomNewsBaseContext> options) : base(options)
    {

    }

    #region Entities

    public virtual DbSet<News> News { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<NewsGroup> NewsGroups { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = typeof(QomNewsBaseContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }
}