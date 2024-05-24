using ExpressNews.Data;
using ExpressNews.Models.Database;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace ExpressNews.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public ArticleService(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }

        

        public void AddArticle(Article newArticle, List<IFormFile> formImages)
        {
            newArticle.DateStamp = DateTime.Now;
            newArticle.Category1 = "World";
            newArticle.Status = "Draft";
            newArticle.UserId = 1;
            newArticle.ImageLink = "https://ichef.bbci.co.uk/news/800/cpsprodpb/0536/live/715d8880-175c-11ef-8a11-6d604e5f7bb3.jpg.webp";


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
            article.Category1 = "World";
            //article.Status = "Draft";
            article.UserId = 1;
            article.ImageLink = "https://ichef.bbci.co.uk/news/800/cpsprodpb/0536/live/715d8880-175c-11ef-8a11-6d604e5f7bb3.jpg.webp";

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

    }

    
}
