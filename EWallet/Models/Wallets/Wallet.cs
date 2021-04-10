namespace Models.Wallets
{
    public enum Currency
    {
        USD,
        EUR,
        UAH
    }
    public class Wallet
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
        public Currency Currency { get; set; }
        public string FileName { get; set; }
    }
}
