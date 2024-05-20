using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.Controllers
{
    public class SubscriptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
