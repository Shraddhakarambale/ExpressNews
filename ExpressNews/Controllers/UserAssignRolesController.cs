using ExpressNews.Models.ViewModel;
using ExpressNews.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExpressNews.Controllers
{
    public class UserAssignRolesController : Controller
    {
        private readonly IUserInterface _userService;
        private readonly IConfiguration _configuration;

        public UserAssignRolesController(IUserInterface userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<UserVM> userVMList = new List<UserVM>();
            
            userVMList = _userService.GetUsers();
                        
            return View(userVMList);
        }
    }
}
