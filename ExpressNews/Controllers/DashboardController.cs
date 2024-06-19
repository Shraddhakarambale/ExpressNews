using ExpressNews.Models.ViewModel;
using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUserInterface _userService;
        private readonly IArticleService _articleService;
        private readonly ISubscriptionService _subscriptionService;
        private readonly IConfiguration _configuration;

        public DashboardController(IUserInterface userService, IConfiguration configuration,IArticleService articleService,ISubscriptionService subscriptionService)
        {
            _userService = userService;
            _configuration = configuration;
            _articleService = articleService;
            _subscriptionService = subscriptionService;


        }
        public IActionResult Index()

        {
           DashboardVM dashboardVM = new DashboardVM();
            ViewBag.MemberCount = _userService.GetMemberCount();
            ViewBag.JournalistCount = _userService.GetJournalistCount();
            ViewBag.EditorCount = _userService.GetEditorCount();
            ViewBag.SubscribedCount = _subscriptionService.GetSubsribedCount();
            ViewBag.NonSubscribedCount = _subscriptionService.GetNonSubsribedCount();
            ViewBag.basicCount = _subscriptionService.GetBasicCount();
            ViewBag.premiumCount= _subscriptionService.GetPremiumCount();
            var categoryCounts = _articleService.GetArticleCategoryCounts();
            ViewBag.CategoryCounts = categoryCounts;
            dashboardVM.articles_Views = _articleService.MostViewedArticles();
            dashboardVM.articles_Likes = _articleService.MostLikedArticles();
            dashboardVM.articles_DisLikes = _articleService.MostDisLikedArticles();



            return View(dashboardVM);

        }
        public IActionResult SubsriptionChart()
        {
            return View();

        }
            
    }
}
