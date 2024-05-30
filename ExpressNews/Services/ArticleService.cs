using ExpressNews.Data;
using ExpressNews.Models.Database;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using ExpressNews.Models;
using Microsoft.AspNetCore.Identity;

namespace ExpressNews.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManagement;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ArticleService(ApplicationDbContext db, IConfiguration configuration, UserManager<User> userManagement, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _configuration = configuration;
            _userManagement = userManagement;
            _httpContextAccessor = httpContextAccessor;
        }

        

        public void AddArticle(Article newArticle, List<IFormFile> formImages)
        {
            newArticle.DateStamp = DateTime.Now;
            string userFirstName = _httpContextAccessor.HttpContext.Session.GetString("UserFirstName");
            string userLastName = _httpContextAccessor.HttpContext.Session.GetString("UserLastName");
            newArticle.Status = "Draft";
            newArticle.UserName = userFirstName + " " + userLastName;

            newArticle.ImageLink = "https://dummyimage.com/600x400/000/fff";


            _db.Articles.Add(newArticle);
            _db.SaveChanges();

            
        }

        private string SaveImageAndGetLink(IFormFile formImage)
        {
            
            var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Image");
            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }

            
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(formImage.FileName);
            var filePath = Path.Combine(imagesPath, uniqueFileName);

            
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                formImage.CopyTo(stream);
            }

            
            return "/Image/" + uniqueFileName;
        }


        public List<Article> GetArticles()
        {
            return _db.Articles.OrderByDescending(a => a.DateStamp).ToList();
            
        }

        public Article UploadFilesToContainer(Article newArticle)
        {
            throw new NotImplementedException();
        }

        public void UpdateArticle(Article article)
        {
            article.DateStamp = DateTime.Now;
            article.DateStamp = DateTime.Now;
            string userFirstName = _httpContextAccessor.HttpContext.Session.GetString("UserFirstName");
            string userLastName = _httpContextAccessor.HttpContext.Session.GetString("UserLastName");
            article.Status = "Draft";
            article.UserName = userFirstName + " " + userLastName;

            article.ImageLink = "https://dummyimage.com/600x400/000/fff";

            _db.Update(article);
            _db.SaveChanges();
        }

        public Article GetArticleById(int id) 
        {

            var article = _db.Articles.FirstOrDefault(a => a.Id == id);
            return article;
        }

        public Article GetBreakingNews( )
        {
            Article article = new Article();
            article = _db.Articles.FirstOrDefault(a => a.IsBreaking==true) ;
            return article;
        }
        public Article GetArticleForFrontPage()
        {
            Article article = new Article();
            article = _db.Articles.FirstOrDefault(a => a.IsBreaking == false);
            return article;
        }



        public void SubmitArticle(Article article)
        {
            article.DateStamp = DateTime.Now;
            
            string userFirstName = _httpContextAccessor.HttpContext.Session.GetString("UserFirstName");
            string userLastName = _httpContextAccessor.HttpContext.Session.GetString("UserLastName");
            article.UserName = userFirstName + " " + userLastName;

            article.ImageLink = "https://dummyimage.com/600x400/000/fff";
            _db.Update(article);
            _db.SaveChanges();
        }

        public Article GetArticleDetails(int id)
        {
            var article = _db.Articles
                        .FirstOrDefault(a => a.Id == id);

            if (article == null)
            {
                throw new Exception("Article not found");
            }

            return article;
        }

        public void DeleteArticle(int id)
        {
            var article = _db.Articles.Find(id);
            if (article != null)
            {
                _db.Articles.Remove(article);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Article not found");
            }
        }

        public List<Article> GetLatestArticles(int count)
        {
            var LatestArticles = _db.Articles.OrderByDescending(a => a.DateStamp).Take(count).ToList();
            return LatestArticles;

        }

        public List<Article> GetArticleByCategory(string category)
        {

            var article = _db.Articles.OrderByDescending(a => a.Category1 == "Local").ToList();
            return article;
        }

    }

    
}
