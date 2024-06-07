
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
            var allUsers = _userManagement.Users.Where(u=>u.IsEmployee==true).OrderByDescending(u => u.Id).ToList();
            foreach (var user in allUsers)
            {
                userVMs.Add(new UserVM
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName, 
                    LastName = user.LastName,
                    Role = user.Role,
                   // IsEmployee = user.IsEmployee,
                    //IsDeleted = user.IsDeleted
                });
            }

            return userVMs;

        }

        public void SaveUserRole(UserVM user)
        {
            // Your logic to save the user's role to the database
            var dbUser = _db.Users.Find(user.Id);
            //var dbRole = _db.Roles.Find(user.Role);
            if (dbUser != null)
            {
                dbUser.Role = user.Role;

                //if (dbRole != null)
                //{
                    
                //}

                _db.SaveChanges();
            }
        }

    }

}
