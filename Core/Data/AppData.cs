using Core.Helpers;
using System;
using System.Linq;

namespace Core.Data
{
    public class AppData
    {
        public static void Seed(AppDbContext context)
        {
            if (context.BlogPosts.Any())
                return;

            context.Authors.Add(new Author
            {
                AppUserName = "admin",
                Email = "admin@us.com",
                DisplayName = "Administrator",
                Avatar = "data/admin/avatar.png",
                Bio = "<p>Something about <b>administrator</b>, maybe HTML or markdown formatted text goes here.</p><p>Should be customizable and editable from user profile.</p>",
                IsAdmin = true,
                Created = DateTime.UtcNow.AddDays(-120)
            });

            context.Authors.Add(new Author
            {
                AppUserName = "demo",
                Email = "demo@us.com",
                DisplayName = "Commum User",
                Bio = "Short description about this user and blog.",
                Created = DateTime.UtcNow.AddDays(-110)
            });

            context.SaveChanges();

            var adminId = context.Authors.Single(a => a.AppUserName == "admin").Id;
            var demoId = context.Authors.Single(a => a.AppUserName == "demo").Id;

            context.BlogPosts.Add(new BlogPost
            {
                Title = "Welcome to Blogifier!",
                Slug = "welcome-to-blogifier!",
                Description = SeedData.FeaturedDesc,
                Content = SeedData.PostWhatIs,
                Categories = "welcome,blog",
                AuthorId = adminId,
                Cover = "data/admin/cover-blog.png",
                PostViews = 5,
                Rating = 4.5,
                IsFeatured = true,
                Published = DateTime.UtcNow.AddDays(-100)
            });

            context.BlogPosts.Add(new BlogPost
            {
                Title = "Blogifier Features",
                Slug = "blogifier-features",
                Description = "List of the main features supported by Blogifier, includes user management, content management, plugin system, markdown editor, simple search and others. This is not the full list and work in progress.",
                Content = SeedData.PostFeatures,
                Categories = "blog",
                AuthorId = adminId,
                Cover = "data/admin/cover-globe.png",
                PostViews = 15,
                Rating = 4.0,
                Published = DateTime.UtcNow.AddDays(-55)
            });

            context.BlogPosts.Add(new BlogPost
            {
                Title = "user commum post",
                Slug = "usercomum-post",
                Description = "Meu blog Simples",
                Content = SeedData.PostDemo,
                AuthorId = demoId,
                Cover = "data/demo/demo-cover.jpg",
                PostViews = 25,
                Rating = 3.5,
                Published = DateTime.UtcNow.AddDays(-10)
            });

            context.Notifications.Add(new Notification
            {
                Notifier = "Blogifier",
                AlertType = AlertType.Primary,
                AuthorId = 0,
                Content = "Welcome to Blog",
                Active = true,
                DateNotified = SystemClock.Now()
            });

            context.SaveChanges();
        }
    }

    public class SeedData
    {
        public static readonly string FeaturedDesc = @"||BLOG PESSOAL SIMPLES||
#### To login:
* User: admin   * User: demo   
* Pswd: admin   * Pswd: demo     ";

        public static readonly string PostWhatIs = @"

3. Use admin/admin to log in as admininstrator
4. Use demo/demo to log in as user

![Demo-1.png](/data/admin/admin-editor.png)";

        public static readonly string PostFeatures = @"
![file-mgr.png](/data/admin/admin-files.png)
";

        public static readonly string PostDemo = @" Blog Simples  :)

#### To login:
* User: demo
* Pswd: demo";

    }
}
