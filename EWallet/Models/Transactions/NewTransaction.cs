using Models.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Transactions
{
    public class NewTransaction
    {
        public DateTime DateTime { get; set; }
        public decimal Sum { get; set; }
        public string Description { get; set; }
        public Currency Currency { get; set; }

    }
}
