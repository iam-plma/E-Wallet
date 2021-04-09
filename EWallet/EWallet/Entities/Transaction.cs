using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Entities
{
    public class Transaction : EntityBase
    {
        private User _creator;

        private Category _category;
        private decimal _sum;
        private string _description;
        private DateTime _date;
        private Currency _currency;

        private object[] _files;

        public decimal Sum { get => _sum; set => _sum = value; }
        public string Description { get => _description; set => _description = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public Category Category { get => _category; set => _category = value; }
        public Currency Currency { get => _currency; set => _currency = value; }
        public User Creator { get => _creator; set => _creator = value; }

        public Transaction(Category category, Currency currency, decimal sum, string description, User creator)
        {
            _category = category;
            _sum = sum;
            Currency = currency;
            _description = description;
            _date = DateTime.Today;

            Creator = creator;
        }

        public Transaction()
        {
            _date = DateTime.Today;
        }

        public override bool Validate()
        {
            bool result = true;

            if (Sum == 0)
                result = false;
            if (!_category.IsValid)
                result = false;

            return result;
        }
    }
}
