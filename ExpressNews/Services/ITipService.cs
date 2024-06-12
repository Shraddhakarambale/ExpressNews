using ExpressNews.Models.Database;

namespace ExpressNews.Services
{
    public interface ITipService
    {
         List<Tip> GetTips();
         void AddTip(Tip tips);
        void UpdateTip(Tip tips);
        Tip GetTipById(int id);
        Tip GetTipDetails(int id);
        void DeleteTip(int id);
        Tip UploadFilesToContainer(Tip tip);
    }
}
