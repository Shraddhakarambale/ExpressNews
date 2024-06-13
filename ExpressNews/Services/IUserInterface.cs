using ExpressNews.Models;
using ExpressNews.Models.Database;
using ExpressNews.Models.ViewModel;

namespace ExpressNews.Services
{
    public interface IUserInterface
    {
        List<UserVM> GetUsers();
        public void SaveUserRole(UserVM user);
        public int GetMemberCount();
        public int GetJournalistCount();
        public int GetEditorCount();
    }
}
