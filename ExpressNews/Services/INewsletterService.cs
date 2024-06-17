using ExpressNews.Models.Database;

namespace ExpressNews.Services
{
    public interface INewsletterService
    {
        List<NewsLetter> GetNewsletter();
        void AddNewsletter(NewsLetter newsLetter);
    }
}
