using ExpressNews.Data;
using ExpressNews.Models;
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

        [HttpPost]
        public IActionResult Index([FromBody] List<UserVM> users)
        {
            foreach (var user in users)
            {
                // Process each user, e.g., save to database
                _userService.SaveUserRole(user);
            }
            return RedirectToAction("Index"); // Redirect to a relevant page
            return Ok(new { message = "Roles assigned successfully!" });  // Return the view with the model in case of validation errors
        }

        
    }
}
