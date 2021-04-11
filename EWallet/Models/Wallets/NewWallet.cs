using Models.Categories;
using System.Collections.Generic;

namespace Models.Wallets
{
    public class NewWallet
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
        public Currency Currency { get; set; }
        public List<Category> Categories { get; set; }
    }
}
