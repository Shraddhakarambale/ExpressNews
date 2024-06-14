using ExpressNews.Migrations;
using ExpressNews.Models.Database;
using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;


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
            return View();
        }
        [HttpPost]
        public IActionResult Create(NewsLetter newsLetter)
        {
            _NewsletterServices.AddNewsletter(newsLetter);

           
            return RedirectToAction("Index");

        }


    }
}
