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
            return View(_subscriptionService.GetSubscriptionType());
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
                return RedirectToAction(nameof(SubscriptionTypeList)); 
            }
            return View(subscriptionType);
        }



        public IActionResult SubscriptionTypeList()
        {
            return View(_subscriptionService.GetSubscriptionType());
        }

        public IActionResult EditSubscriptionType(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(NotFound));
            }

            var subscriptionType = _subscriptionService.GetSubscriptionTypeById(id.Value);
            if (subscriptionType == null)
            {
                return RedirectToAction(nameof(NotFound));
            }
            return View(subscriptionType);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditSubscriptionType(int id, [Bind("Id,TypeName,Description,Price")] SubscriptionType subscriptionType)
        {
            if (id != subscriptionType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _subscriptionService.UpdateSubscriptionType(subscriptionType);
                return RedirectToAction(nameof(SubscriptionTypeList));
            }
            return View(subscriptionType);
        }

        public IActionResult NotFound()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteSubscriptionType(int id)
        {
            _subscriptionService.DeleteSubscriptionType(id);
            return RedirectToAction(nameof(SubscriptionTypeList));
        }

    }
}
