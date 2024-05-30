using ExpressNews.Models.Database;

namespace ExpressNews.Services
{
    public interface ISubscriptionService
    {
        List<Subscription> GetSubscriptionByUserId (int id);
        void AddSubscriptionType(SubscriptionType subscriptionType);
    }
}
