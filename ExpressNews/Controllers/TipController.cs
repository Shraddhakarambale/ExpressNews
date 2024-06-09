using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.Controllers
{
    public class TipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
