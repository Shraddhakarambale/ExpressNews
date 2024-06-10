using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.Controllers
{
    public class SportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
