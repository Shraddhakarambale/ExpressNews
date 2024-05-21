using ExpressNews.Models.Database;
using ExpressNews.Models.ViewModel;
using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IConfiguration _configuration;

        public ArticleController(IArticleService articleService, IConfiguration configuration)
        {
            _articleService = articleService;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            
            return View(_articleService.GetArticles());
        }

        public IActionResult SingleArticle(int id)
        {
            ArticleVM obj = new ArticleVM();
            obj.ArticleObj = _articleService.GetArticleById(1);

            return View(obj);
        }
        public IActionResult AddArticle()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddArticle(Article newArticle)
        {
            if (ModelState.IsValid)
            {
                _articleService.AddArticle(newArticle, newArticle.FormImages);
                return RedirectToAction("Index");
            }
            return View(newArticle);

            
        }
    }
}
