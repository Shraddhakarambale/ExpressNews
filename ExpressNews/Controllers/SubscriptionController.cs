using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly IConfiguration _configuration;

        public SubscriptionController(ISubscriptionService subscriptionService, IConfiguration configuration)
        {
            _subscriptionService = subscriptionService;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View(_subscriptionService.GetSubscriptionType());
        }

        public IActionResult UserSubscription() 
        {
            
            return View(_subscriptionService.GetSubscriptionByUserId(1));
        }
        
    }
}
