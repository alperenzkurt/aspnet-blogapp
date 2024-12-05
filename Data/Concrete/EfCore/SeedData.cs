using aspnet_blogapp.Entity;
using Microsoft.EntityFrameworkCore;

namespace aspnet_blogapp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if(!context.Tags.Any()) //kayit yoksa
                {
                    context.Tags.AddRange(
                        new Tag {Text = "web programlama"},
                        new Tag {Text = "backend"},
                        new Tag {Text = "frontend"},
                        new Tag {Text = "fullstack"},
                        new Tag {Text = "php"}
                    );
                    context.SaveChanges();
                }
                
                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User {UserName = "alperenozkurt"},
                        new User {UserName = "ferhatyilmaz"}
                    );
                    context.SaveChanges();
                }

                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post {
                            Title = "Asp.net core",
                            Content = "Asp.net core dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            UserId = 1,},
                        new Post {
                            Title = "Php",
                            Content = "Php dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            UserId = 1},
                        new Post {
                            Title = "Django",
                            Content = "Django dersleri",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-5),
                            Tags = context.Tags.Take(4).ToList(),
                            UserId = 2}
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}