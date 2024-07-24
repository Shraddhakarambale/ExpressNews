namespace ExpressNews.Models
{
    public class OldArticle
    {
        public int Id { get; set; }
       // public string LinkText { get; set; }
        public string HeadLine {  get; set; }
        public string ContentSummary { get; set; }

        public string ImageLink { get; set; }
        public DateTime DateStamp { get; set; }

    }
}
