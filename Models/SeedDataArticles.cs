using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlogApp.Data;
using System;
using System.Linq;

namespace BlogApp.Models
{
    public static class SeedDataArticles
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcArticleContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcArticleContext>>()))
            {
                // Look for any movies.
                if (context.Article.Any())
                {
                    return;   // DB has been seeded
                }

                context.Article.AddRange(
                    new Article
                    {
                        Title = "When Harry Met Sally",
                        Body = "Lorem ipsum dolo"
                    },

                    new Article
                    {
                        Title = "Ghostbusters ",
                        Body = "Lorem ipsum dolo"
                    },

                    new Article
                    {
                        Title = "Ghostbusters 2",
                        Body = "Lorem ipsum dolo"
                    },

                    new Article
                    {
                        Title = "Rio Bravo",
                        Body = "Lorem ipsum dolo"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}