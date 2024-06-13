namespace ExpressNews.Models.Database
{
    public class NewsLetter
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Category1 { get; set; }

        public string Category2 { get; set; }

        public string Category3 { get; set; }

        public string Category4 { get; set; }
        public string Status { get; set; }

        public bool IsTermsAndConditions { get; set; }

        public DateTime Created { get; set; }
    }
}
