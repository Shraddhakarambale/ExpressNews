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
            // Save the article first to generate the Id
            _db.Articles.Add(newArticle);
            _db.SaveChanges();

            // Process and save each image
            foreach (var formImage in formImages)
            {
                var imageLink = new ImageLink
                {
                    ArticleId = newArticle.Id,
                    Link = SaveImageAndGetLink(formImage) // Assume this method saves the image and returns the link
                };
                _db.ImageLinks.Add(imageLink);
            }
            _db.SaveChanges();
        }

        private string SaveImageAndGetLink(IFormFile formImage)
        {
            // Ensure the Images directory exists
            var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
            if (!Directory.Exists(imagesPath))
            {
                Directory.CreateDirectory(imagesPath);
            }

            // Generate a unique filename for the image
            var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(formImage.FileName);
            var filePath = Path.Combine(imagesPath, uniqueFileName);

            // Save the image to the server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                formImage.CopyTo(stream);
            }

            // Return the URL or path to the saved image
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

       
    }
    
}
