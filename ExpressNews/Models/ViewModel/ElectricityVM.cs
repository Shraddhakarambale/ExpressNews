namespace ExpressNews.Models.ViewModel
{
    public class ElectricityVM
    {
        public string RowKey { get; set; }
        public string PartitionKey { get; set; }
        public string Timestamp { get; set; }
        public decimal Price { get; set; }
    }
}
