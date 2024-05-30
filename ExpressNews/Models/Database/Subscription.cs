namespace ExpressNews.Models.Database
{
    public class Subscription
    {
        public int Id { get; set; }

        public int SubscriptionTypeId { get; set; }

        public decimal Price { get; set; }

        public DateTime Created { get; set; }

        public DateTime Expires { get; set; }

        public bool PaymentComplete { get; set; }

        //public virtual User User { get; set; }
        //public virtual SubscriptionType SubscriptionType { get; set; }
    }
 
}
