using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.Controllers
{
    public class Subscription : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
