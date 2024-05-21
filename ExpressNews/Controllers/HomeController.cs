using ExpressNews.Models;
using ExpressNews.Models.ViewModel;
using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpressNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService)
        {
            _articleService = articleService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ArticleVM model = new ArticleVM();
            model.ArticleList = _articleService.GetArticles();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Tip()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
