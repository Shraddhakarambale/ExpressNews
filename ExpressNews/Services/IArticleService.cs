using ExpressNews.Models.Database;

namespace ExpressNews.Services
{
    public interface IArticleService
    {
        List<Article> GetArticles();
        void AddArticle(Article newArticle, List<IFormFile> formImages);

        //void AddImageLink(ImageLink imageLink);

        Article UploadFilesToContainer(Article newArticle);

        //Status GetStatus(int id);
        Article GetArticleById(int id);
        Article GetBreakingNews();
        Article GetArticleForFrontPage();
        void UpdateArticle(Article article);

        Article GetArticleDetails(int id);

        void DeleteArticle(int id);
    }
}
