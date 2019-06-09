namespace CoinbasePro.Models.Responses
{
    public class Product
    {
        public string Id { get; set; }
        public string BaseCurrency { get; set; }
        public string QuoteCurrency { get; set; }
        public string BaseMinimumSize { get; set; }
        public string BaseMaximumSize { get; set; }
        public string QuoteIncrement { get; set; }
    }
}