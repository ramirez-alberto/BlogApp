using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BlogApp.Models;

namespace BlogApp.Data;
public class MvcArticleContext : DbContext
{
    public MvcArticleContext(DbContextOptions<MvcArticleContext> options)
        : base(options)
    {
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is Article && (
                    e.State == EntityState.Added
                    || e.State == EntityState.Modified));

        foreach (var entityEntry in entries)
        {
            ((Article)entityEntry.Entity).UpdatedDate = DateTime.Now;

            if (entityEntry.State == EntityState.Added)
            {
                ((Article)entityEntry.Entity).CreatedDate = DateTime.Now;
            }
        }

        return base.SaveChangesAsync();
    }
    public DbSet<BlogApp.Models.Article> Article { get; set; } = default!;
    public DbSet<BlogApp.Models.Comment> Comment { get; set; } = default!;
}

