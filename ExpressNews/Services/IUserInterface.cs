using ExpressNews.Models;
using ExpressNews.Models.Database;

namespace ExpressNews.Services
{
    public interface IUserInterface
    {
        List<User> GetUsers();

    }
}
