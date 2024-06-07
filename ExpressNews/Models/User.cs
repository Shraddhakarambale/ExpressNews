using Microsoft.AspNetCore.Identity;

namespace ExpressNews.Models
{
    public class User: IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public string? Role {  get; set; }

        public bool? IsEmployee { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
