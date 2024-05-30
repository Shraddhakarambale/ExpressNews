using ExpressNews.Models.Database;
using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return View();
        }

        public IActionResult UserSubscription() 
        {
            
            return View(_subscriptionService.GetSubscriptionByUserId(1));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("TypeName,Description,Price")] SubscriptionType subscriptionType)
        {
            if (ModelState.IsValid)
            {
                 _subscriptionService.AddSubscriptionType(subscriptionType);
                return RedirectToAction(nameof(Index)); 
            }
            return View(subscriptionType);
        }
    }
}
