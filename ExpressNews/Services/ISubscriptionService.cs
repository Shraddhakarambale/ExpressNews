using ExpressNews.Models.Database;
using ExpressNews.Models.ViewModel;

namespace ExpressNews.Services
{
    public interface ISubscriptionService
    {
        List<Subscription> GetSubscriptionByUserId (int id);

        void AddSubscriptionType(SubscriptionType subscriptionType);

        SubscriptionTypeVM GetSubscriptionType();

    }
}
