using Azure.Storage.Blobs;
using ExpressNews.Data;
using ExpressNews.Models;
using ExpressNews.Models.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
namespace ExpressNews.Services
{
    public class NewsletterServices: INewsletterService
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManagement;
        private readonly IEmailSender _emailSender;
        public NewsletterServices (ApplicationDbContext db, IConfiguration configuration, IEmailSender emailSender)
        {
            _db = db;
            _configuration = configuration;
            _emailSender = emailSender;
        }

        public List<NewsLetter> GetNewsletter()
        {
            var newsletter = _db.NewsLetters.ToList();
            return newsletter;
        }

        public void AddNewsletter(NewsLetter newsLetter)
        {
            if (newsLetter.Category2 == null) newsLetter.Category2 = "N/A";
            if (newsLetter.Category3 == null) newsLetter.Category3 = "N/A";
            if (newsLetter.Category4 == null) newsLetter.Category4 = "N/A";

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

            var html = "";
            html += "<html>";
            html += "<body>";
            html += "<div class='container'>";
            html += "<div class='header'>";
            html += "<h1>Thank You for Subscribing!</h1>";
            html += "</div>";
            html += "<div class='content'>";
            html += "<h2>Hi there,</h2>";
            html += "<p>Thank you for subscribing to our newsletter! We're excited to have you on board. You will now receive the latest updates, news, and special offers directly in your inbox.</p>";
            html += "<p>If you have any questions or need further assistance, feel free to<a href='mailto:expressnewscontact@gmail.com'> contact us</a>.</p>";
            html += "<a href ='https://expressnews.azurewebsites.net/' class='button'>Visit our website</a>";
            html += "</div>";
            html += "<div class='footer'>";
            html += "<p>&copy; 2024 Express News.All rights reserved.</p>";
            html += "</div>";
            html += "</div>";
            html += "</body>";
            html += "</html>";

            _emailSender.SendEmailAsync(newsLetter.EmailAddress, "Confirm your Subscribing!", html);
        }
        public NewsLetter GetNewsletterCategoryByUser(string userName)
        {
            var newsletter = _db.NewsLetters.Where(a => a.EmailAddress == userName).FirstOrDefault();

            return newsletter;
        }

    }
}
