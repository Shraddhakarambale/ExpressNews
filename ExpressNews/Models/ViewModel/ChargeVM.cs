namespace ExpressNews.Models.ViewModel
{
    public class ChargeVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Amount { get; set; }
        public string SubType { get; set; }
        public string PublishableKey { get; set; }
    }
}
