using ExpressNews.Models.Database;
using ExpressNews.Models.ViewModel;
using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.Controllers
{
    public class SportController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ILogger<SportController> _logger;

        public SportController(ILogger<SportController> logger, IArticleService articleService)
        {
            _articleService = articleService;
            _logger = logger;
        }
        public IActionResult Index()
        {
            List<Article> modelList = new List<Article>();
            modelList = _articleService.GetArticleByCategory("Sport");
            return View(modelList);

        }
    }
}
