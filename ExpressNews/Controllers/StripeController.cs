using ExpressNews.Models.Database;
using ExpressNews.Models.ViewModel;
using ExpressNews.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Newtonsoft.Json;
using Stripe;
using Stripe.FinancialConnections;
using System.Numerics;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace ExpressNews.Controllers
{
    public class StripeController : Controller
    {
        private readonly StripeSettings _stripeSettings;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IEmailSender _emailSender;
        public StripeController(IOptions<StripeSettings> stripeSettings, ISubscriptionService subscriptionService, IEmailSender emailSender)
        {
            _stripeSettings = stripeSettings.Value;
            _subscriptionService = subscriptionService;
            _emailSender = emailSender;
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

            var html = "<html>";
            html += "<body>";
            html += "<div class='container'>";  
            html += "<h1> Payment Confirmation</h1>";
            html += "<p>Hi Customer,</p>";
            html += "<p>Thank you for your payment! Your transaction was successful.</p>";
            html += $"<p>Subscriptin Type: <strong>{model.SubType}</strong></p>";
            html += $"<p>Expiration Date: <strong>{model.ExpirationDate}</strong></p>";
            html += $"<p>Amount Paid: <strong> SEK{model.Amount}</strong></p>";
            html += "<a href='https://expressnews.azurewebsites.net/' class='btn btn-home mt-3 fw-bold'> Go to Homepage</a>";
            html += "<footer>";
            html += "<p>If you have any questions, please contact our support team or email us : <a href='https://expressnews.azurewebsites.net/Home/ContactUs' class='btn btn-home mt-3 fw-bold'> Contact Us</a>.</p>";
            html += "</footer>";
            html += "</div>";
            html += "</body>";
           html += " </html>";

            _emailSender.SendEmailAsync(model.Email, "Confirm your payment", html);

            return View("ChargeConfirmation");
        }

    }
}
