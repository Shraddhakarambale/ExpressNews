using ExpressNews.Models.Database;
using ExpressNews.Models.ViewModel;

namespace ExpressNews.Services
{
    public interface ISubscriptionService
    {
        List<Subscription> GetSubscriptionByUserId ();

        void AddSubscriptionType(SubscriptionType subscriptionType);

        SubscriptionTypeVM GetSubscriptionType();

        SubscriptionType GetSubscriptionTypeById(int id);
        void UpdateSubscriptionType(SubscriptionType subscriptionType);

        void DeleteSubscriptionType(int id);

        List<Subscription> GetCurrentSubscriptionByUserId(string userName);

        List<SubscriptionVM> GetSubscriptionByUserDetails();

        int GetBasicCount();
        int GetPremiumCount();
     
        int GetSubsribedCount();
        int GetNonSubsribedCount();

    }
}
