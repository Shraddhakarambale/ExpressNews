namespace ExpressNews.Models.ViewModel
{
    public class ElectricityVM
    {
        //public string RowKey { get; set; }
        //public string PartitionKey { get; set; }
        //public string Timestamp { get; set; }
        //public decimal Prices { get; set; }
        public List<string> Timestamp { get; set; } = new List<string>();
        public List<decimal> SE1Prices { get; set; } = new List<decimal>();
        public List<decimal> SE2Prices { get; set; } = new List<decimal>();
        public List<decimal> SE3Prices { get; set; } = new List<decimal>();
        public List<decimal> SE4Prices { get; set; }= new List<decimal>();
    }
}
