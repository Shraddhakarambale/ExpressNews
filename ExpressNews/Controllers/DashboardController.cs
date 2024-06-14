using ExpressNews.Models.ViewModel;
using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUserInterface _userService;
        private readonly IConfiguration _configuration;

        public DashboardController(IUserInterface userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;


        }
        public IActionResult Index()
        
        {
            ViewBag.MemberCount = _userService.GetMemberCount();
            ViewBag.JournalistCount = _userService.GetJournalistCount();
            ViewBag.EditorCount = _userService.GetEditorCount();

            return View();
            
        }
    }
}
