
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace ExpressNews.Models.Database
{
    public class Subscription
    {
        public int Id { get; set; }

        public int SubscriptionTypeId { get; set; }

        public decimal Price { get; set; }

        public DateTime Created { get; set; }

        public DateTime Expires { get; set; }


        [Display(Name = "Payment Complete")]
        public bool PaymentComplete { get; set; }

        [Display (Name = "Subscription") ]
        public string SubscriptionTypeName { get; set; }


        [Display(Name = "User Name")]
        public string UserName {  get; set; }
        public string SubsTypeDetails { get; set; }

        //public virtual User User { get; set; }
        //public virtual SubscriptionType SubscriptionType { get; set; }
    }
 
}
