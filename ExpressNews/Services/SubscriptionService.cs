using ExpressNews.Data;
using ExpressNews.Models;
using ExpressNews.Models.Database;
using ExpressNews.Models.ViewModel;
using Microsoft.AspNetCore.Identity;

namespace ExpressNews.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        public SubscriptionService(ApplicationDbContext db, IConfiguration configuration, UserManager<User> userManagement, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _configuration = configuration;
            
        }

        public List<Subscription> GetSubscriptionByUserId(int id)
        {
            var subscription = _db.Subscriptions.OrderByDescending(a => a.Id == id).ToList();
            return subscription;
        }
        public SubscriptionTypeVM GetSubscriptionType()
        {
            SubscriptionTypeVM model = new SubscriptionTypeVM();
            model.SubTypeList = _db.SubscriptionTypes.OrderByDescending(a => a.Id ).ToList();
            return model;
        }
    }
}
