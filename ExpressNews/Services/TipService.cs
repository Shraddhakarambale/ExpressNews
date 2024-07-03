using Azure.Storage.Blobs;
using ExpressNews.Data;
using ExpressNews.Models;
using ExpressNews.Models.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace ExpressNews.Services
{
    public class TipService:ITipService
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManagement;
        public TipService(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        public List<Tip> GetTips()
        {
            var tip =_db.Tips.Where(a => a.IsDeleted != true && a.IsApproved!=true).ToList();
            return tip;
        }
        public Tip GetTipById(int id)
        {

            var tip = _db.Tips.FirstOrDefault(t => t.Id == id);
            return tip;
        }

        public Tip GetOldTipById(int id)
        {

            var tip = _db.Tips.AsNoTracking().FirstOrDefault(t => t.Id == id);
            return tip;
        }
        public void AddTip(Tip tips)
        {
            tips.Created = DateTime.Now;
            _db.Tips.Add(tips);
            _db.SaveChanges();
        }
        public void UpdateTip(Tip tips)
        {
            Article article = new Article();

            article.Category1 = "N/A";
            article.Category2 = "N/A";
            article.Category3 = "N/A";
            article.LinkText = tips.Subject;
            article.DisLikes =0;
            article.Status = "Submitted";
            article.IsEditorChoice = false;
            article.Content = tips.Description;
            article.ContentSummary = tips.Subject;
            article.DateStamp = DateTime.Now;
            article.FileName = tips.ImageName;
           // article.FormImages = "";
            article.HeadLine = tips.Subject;
            article.ImageDiscription = "";
            article.ImageLink = "https://expressnews.blob.core.windows.net/newscontainer/" + tips.ImageName;
            article.IsBreaking = false;
            article.IsSubsription = false;
            article.Likes = 0;
            article.Views = 0;
            article.UserName = tips.Email;

            _db.Articles.Add(article);


            tips.Created = DateTime.Now;
            _db.Tips.Update(tips);
            _db.SaveChanges();
        }
        public Tip GetTipDetails(int id)
        {
            var tip = _db.Tips
                        .FirstOrDefault(t => t.Id == id);

            if (tip == null)
            {
                throw new Exception("Tip not found");
            }

            return tip;
        }
        public void DeleteTip(int id)
        {
            var tip = _db.Tips.Find(id);
            if (tip != null)
            {
                _db.Tips.Remove(tip);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception("Tip not found");
            }
        }

        public Tip UploadFilesToContainer(Tip tip)
        {
            BlobContainerClient blobServiceClient = new BlobServiceClient(
                                   _configuration["AzureWebJobsStorage"]).GetBlobContainerClient("newscontainer");
            
            foreach (var file in tip.FormImages)
            {
                BlobClient blobClient = blobServiceClient.GetBlobClient(file.FileName);
                using (var stream = file.OpenReadStream())
                {
                    blobClient.Upload(stream);
                }
                tip.ImageName = file.FileName;
            }
            return tip;


        }
    }
}
