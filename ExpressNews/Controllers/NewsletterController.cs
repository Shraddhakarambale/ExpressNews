using ExpressNews.Migrations;
using ExpressNews.Models;
using ExpressNews.Models.Database;
using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;


namespace ExpressNews.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _NewsletterServices;
        private readonly IConfiguration _configuration;
        public NewsletterController(ITipService tipService, IConfiguration configuration, INewsletterService newsletterService)
        {
            _NewsletterServices = newsletterService;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View(_NewsletterServices.GetNewsletter());
        }

        public IActionResult Create()
        {
           string emailAddress = HttpContext.Session.GetString("UserName").ToString();
            
            return View(_NewsletterServices.GetNewsletterCategoryByUser(emailAddress));
        }
        [HttpPost]
        public IActionResult Create(NewsLetter newsLetter)
        {
            newsLetter.Created = DateTime.Now;
            newsLetter.Status = "Active";
            newsLetter.FirstName = HttpContext.Session.GetString("UserFirstName").ToString();
            newsLetter.LastName = HttpContext.Session.GetString("UserLastName").ToString();
            newsLetter.EmailAddress = HttpContext.Session.GetString("UserName").ToString();

            _NewsletterServices.AddNewsletter(newsLetter);

           
            return RedirectToAction("Create");

        }


    }
}
