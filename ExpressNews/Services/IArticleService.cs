using ExpressNews.Models.Database;

namespace ExpressNews.Services
{
    public interface IArticleService
    {
        List<Article> GetArticles();
        void AddArticle(Article newArticle, List<IFormFile> formImages);

        //void AddImageLink(ImageLink imageLink);

        Article UploadFilesToContainer(Article article);

        //Status GetStatus(int id);
        Article GetArticleById(int id);
        Article GetBreakingNews();
        Article GetArticleForFrontPage();
        void UpdateArticle(Article article);
        void SubmitArticle(Article article);
        Article GetArticleDetails(int id);

        void ApproveArticle(Article article);

        void RejectArticle(Article article);
        void DeleteArticle(int id);

        List<Article> GetLatestArticles(int count);

        List<Article> GetPopularArticles(int count);

        public List<Article> GetArticleByCategory(string category);


        Article UpdateArticleValues(Article article);

        List<Article> SearchArticles(string query);

        public List<Article> EditorsChoiceArticles(int count);
    }
}
