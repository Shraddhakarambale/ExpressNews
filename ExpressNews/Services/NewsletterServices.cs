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
            var newsletter2 = _db.NewsLetters.Where(a => a.EmailAddress == newsLetter.EmailAddress).FirstOrDefault();
            if (newsletter2 != null)
            {
                newsletter2.Category1 = newsLetter.Category1;
                newsletter2.Category2 = newsLetter.Category2;
                newsletter2.Category3 = newsLetter.Category3;
                newsletter2.Category4 = newsLetter.Category4;

                _db.NewsLetters.Update(newsletter2);
                _db.SaveChanges();
            }
            else {
                _db.NewsLetters.Add(newsLetter);
                _db.SaveChanges();
            }
        }
        public NewsLetter GetNewsletterCategoryByUser(string userName)
        {
            var newsletter = _db.NewsLetters.Where(a => a.EmailAddress == userName).FirstOrDefault();

            return newsletter;
        }

    }
}
