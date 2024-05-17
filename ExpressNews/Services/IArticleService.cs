using ExpressNews.Models.Database;

namespace ExpressNews.Services
{
    public interface IArticleService
    {
        List<Article> GetArticles();
        void AddArticle(Article newArticle, List<IFormFile> formImages);

        //void AddImageLink(ImageLink imageLink);

        Article UploadFilesToContainer(Article newArticle);
    }
}
