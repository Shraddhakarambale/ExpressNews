using ExpressNews.Data;
using ExpressNews.Models.Database;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

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
            
            _db.Articles.Add(newArticle);
            _db.SaveChanges();

            
            foreach (var formImage in formImages)
            {
                var imageLink = new ImageLink
                {
                    ArticleId = newArticle.Id,
                    Link = SaveImageAndGetLink(formImage)  
                };
                _db.ImageLinks.Add(imageLink);
            }
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

            
            return "/Images/" + uniqueFileName;
        }


        public List<Article> GetArticles()
        {
            return _db.Articles.Include(a => a.Images).ToList();
            
        }

        public Article UploadFilesToContainer(Article newArticle)
        {
            throw new NotImplementedException();
        }

       //public Status GetStatus(int id)
       // {
            
       //     return _db.Status.FirstOrDefault(a => a.Id == id);

       // }
    }
    
}
