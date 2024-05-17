namespace ExpressNews.Models.Database
{
    public class ImageLink
    {
        public int Id { get; set; }
        public string Link { get; set; } = string.Empty;

        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
