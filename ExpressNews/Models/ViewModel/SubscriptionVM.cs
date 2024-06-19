using ExpressNews.Models.Database;
using System.ComponentModel.DataAnnotations;

namespace ExpressNews.Models.ViewModel
{
    public class SubscriptionVM
    {
        public int Id { get; set; }

        public int SubscriptionTypeId { get; set; }

        public decimal Price { get; set; }

        public DateTime Created { get; set; }

        public DateTime Expires { get; set; }

        public bool PaymentComplete { get; set; }
        public string SubscriptionTypeName { get; set; }
        public string UserName { get; set; }
        public string SubsTypeDetails { get; set; }

        public string FirstName { get; set; }   
        public string LastName { get; set; }
    }
}
