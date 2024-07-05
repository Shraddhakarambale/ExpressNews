using ExpressNews.Models.Database;

namespace ExpressNews.Services
{
    public interface IElectricityDataService
    {
        Task<List<ElectricityData>> GetSpotPricesAsync(string area, string date);
    }
}
