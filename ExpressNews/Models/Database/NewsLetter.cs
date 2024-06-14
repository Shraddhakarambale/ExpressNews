using System.ComponentModel.DataAnnotations;

namespace ExpressNews.Models.Database
{
    public class NewsLetter
    {
        public int Id { get; set; }

        [Display (Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]

        public string EmailAddress { get; set; }

        [Display(Name = "Category 1")]

        public string Category1 { get; set; }

        [Display(Name = "Category 2")]

        public string Category2 { get; set; }

        [Display(Name = "Category 3")]
        public string Category3 { get; set; }

        [Display(Name = "Category 4")]
        public string Category4 { get; set; }
        public string Status { get; set; }

        public bool IsTermsAndConditions { get; set; }

        public DateTime Created { get; set; }

    }
}
