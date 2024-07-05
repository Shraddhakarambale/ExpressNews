using Azure;
using Azure.Data.Tables;

namespace ExpressNews.Models.Database
{
    public class ElectricityData: ITableEntity
    {
        public string RowKey { get; set; }
        public string PartitionKey { get; set; }
        public string Price { get; set; }

        // Required properties by ITableEntity
        public DateTimeOffset? Timestamp { get; set; }  // Adjusting the type to DateTimeOffset?
        public ETag ETag { get; set; }
    }
}
