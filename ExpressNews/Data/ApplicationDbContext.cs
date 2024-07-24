using ExpressNews.Models;
using ExpressNews.Models.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpressNews.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        DbSet<User> Users {  get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }

        public DbSet<Tip> Tips { get; set; }

        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<ExpressNews.Models.OldArticle> OldArticle { get; set; } = default!;
    }
}
