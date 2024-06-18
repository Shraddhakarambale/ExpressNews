using Azure.Storage.Blobs;
using ExpressNews.Data;
using ExpressNews.Models;
using ExpressNews.Models.Database;
using Microsoft.AspNetCore.Identity;
namespace ExpressNews.Services
{
    public class NewsletterServices: INewsletterService
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManagement;
        public NewsletterServices (ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        public List<NewsLetter> GetNewsletter()
        {
            var newsletter = _db.NewsLetters.ToList();
            return newsletter;
        }

        public void AddNewsletter(NewsLetter newsLetter)
        {
            
            _db.NewsLetters.Add(newsLetter);
            _db.SaveChanges();
        }
        public NewsLetter GetNewsletterCategoryByUser(string userName)
        {
            var newsletter = _db.NewsLetters.Where(a => a.EmailAddress == userName).FirstOrDefault();

            return newsletter;
        }

    }
}
