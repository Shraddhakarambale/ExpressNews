
using ExpressNews.Data;
using ExpressNews.Models;
using ExpressNews.Models.Database;
using ExpressNews.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ExpressNews.Services
{
    public class UserService : IUserInterface
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManagement;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(ApplicationDbContext db, IConfiguration configuration, UserManager<User> userManagement, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _configuration = configuration;
            _userManagement = userManagement;
            _httpContextAccessor = httpContextAccessor;
        }


        public List<UserVM> GetUsers()
        {
            List<UserVM> userVMs = new List<UserVM>();
            var allUsers = _userManagement.Users.OrderByDescending(u => u.Id).ToList();
            foreach (var user in allUsers)
            {
                userVMs.Add(new UserVM
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName, 
                    LastName = user.LastName
               });
            }

            return userVMs;

        }

    }

}
