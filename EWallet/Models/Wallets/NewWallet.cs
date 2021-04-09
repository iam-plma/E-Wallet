using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Wallets
{
    public class NewWallet
    {
        public string Label { get; set; }
        public string Description { get; set; }
        public decimal Balance { get; set; }
        public Currency Currency { get; set; }
    }
}
