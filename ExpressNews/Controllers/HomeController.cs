using ExpressNews.Models;
using ExpressNews.Models.ViewModel;
using ExpressNews.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpressNews.Controllers
{
   
    public class HomeController : Controller
    {
        //public readonly UserManager<IdentityUser> _userManager;
        //public readonly RoleManager<IdentityRole> _roleManager;
        //public HomeController(
        
        //UserManager<IdentityUser> userManager,
        //RoleManager<IdentityRole> roleManager
        //)
        //{
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //}

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
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
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

        public IActionResult ArticleByCategory(string category)
        {
            ArticleVM model = new ArticleVM();
            model.ArticleList = _articleService.GetArticleByCategory(category);
            model.ArticleObj = _articleService.GetArticleById(2);

            return View(model);
        }
    }

}
