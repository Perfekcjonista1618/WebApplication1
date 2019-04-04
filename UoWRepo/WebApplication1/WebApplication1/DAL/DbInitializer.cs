using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public static class DbInitializer
    {
        public static void Initialize(BloggingContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            //if (context.Blogs.Any())
            //{
            //    return;   // DB has been seeded
            //}


            List<Blog> blogs = new List<Blog>();
            List<Post> posts = new List<Post>();

            blogs.Add(
                new Blog { Name = "HelloRoman" }
                );

            blogs.ForEach(d => context.Blogs.Add(d));
            context.SaveChanges();

            posts.Add(new Post
            {
                BlogId = blogs.First().BlogId,
                Title = "Wstęp do frontend",
                Content = "Użyj View"
            });

            posts.ForEach(d => context.Posts.Add(d));
            context.SaveChanges();
        }
    }
}
