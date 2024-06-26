using ExpressNews.Models.Database;
using ExpressNews.Models.ViewModel;
using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Stripe;
using System.Security.AccessControl;

namespace ExpressNews.Controllers
{
    public class StripeController : Controller
    {
        private readonly StripeSettings _stripeSettings;
        private readonly ISubscriptionService _subscriptionService;
        public StripeController(IOptions<StripeSettings> stripeSettings, ISubscriptionService subscriptionService)
        {
            _stripeSettings = stripeSettings.Value;
            _subscriptionService = subscriptionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Charge(string name, string email, DateTime expirationDate, decimal amount, string subType)
        {

            var model = new ChargeVM
            {
                Amount = amount,
                Name = name,
                Email = email,
                ExpirationDate = expirationDate,
                SubType = subType,
                PublishableKey = _stripeSettings.PublishableKey
            };
           
            TempData["ChargeVM"] = JsonConvert.SerializeObject(model);

            return View(model);
        }

        [HttpPost]
        public IActionResult Charge(string stripeToken)
        {
            var model = JsonConvert.DeserializeObject<ChargeVM>(TempData["ChargeVM"].ToString());

            
            var options = new ChargeCreateOptions
            {
                Amount = (long)(model.Amount * 100), // Convert amount to cents 
                Currency = "SEK",
                Description = "Subcription (" + model.SubType + ") Payments for " + model.Name ,
                Source = stripeToken
            };

            var service = new ChargeService();
            
            Charge charge = service.Create(options);

            var subcription = _subscriptionService.GetSubscriptionTypeByName(model.SubType);

            var modelObj = new SubscriptionVM
            {
                SubscriptionTypeId = subcription.Id,
                Price = model.Amount,
                Created = DateTime.Now,
                Expires = model.ExpirationDate,
                PaymentComplete = true,
                SubscriptionTypeName=model.SubType,
                UserName = model.Email,
                SubsTypeDetails = subcription.Description,
               
            };

            _subscriptionService.UpadateSubscription(modelObj);

            return View("ChargeConfirmation");
        }

    }
}
