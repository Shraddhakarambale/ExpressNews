using Azure.Data.Tables;
using Microsoft.Extensions.Configuration;
using ExpressNews.Models.Database;

namespace ExpressNews.Services
{
    public class ElectricityDataService : IElectricityDataService
    {
        private readonly TableServiceClient _tableServiceClient;
        private readonly string _tableName = "SpotPrices";
        private readonly IConfiguration _configuration;

        public ElectricityDataService(IConfiguration configuration)
        {
            _configuration = configuration;
            _tableServiceClient = new TableServiceClient(_configuration["AzureWebJobsStorage"]);
        }

        public async Task<List<ElectricityData>> GetSpotPricesAsync(string area, string date)
        {
            
            var tableClient = _tableServiceClient.GetTableClient(_tableName);
            var queryResults = tableClient.Query<ElectricityData>().Where(e => e.PartitionKey == area && e.RowKey.StartsWith(date)).ToList();

            return await Task.FromResult(queryResults);
        }
    }
}
