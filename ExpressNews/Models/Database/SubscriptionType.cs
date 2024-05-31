using System.ComponentModel.DataAnnotations;

namespace ExpressNews.Models.Database
{
    public class SubscriptionType
    {
        public int Id { get; set; }


        [Display(Name = "Type Name")]
        public string TypeName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
