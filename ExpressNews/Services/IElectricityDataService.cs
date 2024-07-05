using ExpressNews.Models.Database;
using ExpressNews.Models.ViewModel;

namespace ExpressNews.Services
{
    public interface IElectricityDataService
    {
        Task<List<ElectricityData>> GetSpotPricesAsync(string area, string date);
    }
}
