using ExpressNews.Models.Database;

namespace ExpressNews.Models
{
    public class ArticleCategoryLink
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int CategoryId { get; set; }

       
        public virtual Article Article { get; set; }
        public virtual Category Category { get; set; }
    }
}
