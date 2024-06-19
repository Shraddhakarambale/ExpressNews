using ExpressNews.Models.Database;

namespace ExpressNews.Models.ViewModel
{
    public class DashboardVM
    {
        public int MemberCount { get; set; }

        public List<Article> articles_Views { get; set; }
        public List<Article> articles_Likes { get; set; }
        public List<Article> articles_DisLikes { get; set; }
    }
}
