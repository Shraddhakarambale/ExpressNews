using ExpressNews.Data;
using ExpressNews.Models;
using ExpressNews.Models.Database;
using ExpressNews.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExpressNews.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManagement;
        public SubscriptionService(ApplicationDbContext db, IConfiguration configuration, UserManager<User> userManagement, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _configuration = configuration;
            _userManagement = userManagement;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Subscription> GetSubscriptionByUserId()
        {
            var userName = _httpContextAccessor.HttpContext.Session.GetString("UserName");
            var subscription = _db.Subscriptions.Where(a => a.UserName == userName).ToList();
            return subscription;
        }

        public List<Subscription> GetCurrentSubscriptionByUserId(string userName)
        {
            var subscription = _db.Subscriptions.Where(a => a.UserName == userName && a.Expires > DateTime.Now).ToList();
            return subscription;
        }


        public void AddSubscriptionType(SubscriptionType subscriptionType)
        {
            _db.SubscriptionTypes.Add(subscriptionType);
             _db.SaveChanges();
            
        }


        public SubscriptionTypeVM GetSubscriptionType()
        {
            SubscriptionTypeVM model = new SubscriptionTypeVM();
            model.SubTypeList = _db.SubscriptionTypes.Where(a => a.IsDeleted != true).OrderByDescending(a => a.Id).ToList();
            return model;
        }

        public SubscriptionType GetSubscriptionTypeById(int id)
        {
            return _db.SubscriptionTypes.FirstOrDefault(st => st.Id == id && !st.IsDeleted);
        }

        public void UpdateSubscriptionType(SubscriptionType subscriptionType)
        {
            _db.SubscriptionTypes.Update(subscriptionType);
            _db.SaveChanges();
        }

        public void DeleteSubscriptionType(int id)
        {
            var subscriptionType = _db.SubscriptionTypes.Find(id);
            if (subscriptionType != null)
            {
                subscriptionType.IsDeleted = true;
                _db.SubscriptionTypes.Update(subscriptionType);
                _db.SaveChanges();
            }
        }

    }
}
