using System;
using System.Collections.ObjectModel;
using Prism.Commands;
using Services;
using Models.Transactions;
using EWalletWPF.Navigation;
using Models.Wallets;

namespace EWalletWPF.Wallets
{
    public class WalletStatsViewModel : INavigatable<WalletsNavigatableTypes>
    {
        private Action _gotoWalletsMenu;
        private TransactionService _transactionService;
        private Wallet _wallet;

        private decimal _incomesSum;
        private decimal _expensesSum;
        public DelegateCommand BackCommand { get; }
        public static ObservableCollection<string> Incomes { get; set; }
        public static ObservableCollection<string> Expenses { get; set; }
        public string Balance
        {
            get
            {
                return $"{Math.Round(_wallet.Balance, 2)} ({_wallet.Currency})";
            }
            set{  }
        }

        public decimal IncomeSum
        {
            get
            {
                return Math.Round(_incomesSum, 2);
            }
            set {  }
        }
        public decimal ExpensesSum
        {
            get
            {
                return Math.Round(_expensesSum, 2);
            }
            set {  }
        }

        public WalletsNavigatableTypes Type
        {
            get { return WalletsNavigatableTypes.Stats; }
        }

        public WalletStatsViewModel(Action gotoWalletsMenu)
        {
            _incomesSum = 0;
            _expensesSum = 0;

            _wallet = UserManager.CurrentWallet;

            _gotoWalletsMenu = gotoWalletsMenu;
            BackCommand = new DelegateCommand(_gotoWalletsMenu);

            _transactionService = new TransactionService();
            Incomes = new ObservableCollection<string>();
            Expenses = new ObservableCollection<string>();
            foreach(var transaction in _transactionService.GetWalletLastMonthIncome(_wallet))
            {
                string transactionString = $"{transaction.DateTime} Sum: {transaction.Sum} ({transaction.Currency})";
                if (!String.IsNullOrEmpty(transaction.Description))
                {
                    transactionString += $" - {transaction.Description}";
                }
                Incomes.Add(transactionString);
                _incomesSum += exchangeCurrency(transaction.Sum, transaction.Currency);
            }
            foreach (var transaction in _transactionService.GetWalletLastMonthExpenses(_wallet))
            {
                string transactionString = $"{transaction.DateTime} Sum: {transaction.Sum} ({transaction.Currency})";
                if (!String.IsNullOrEmpty(transaction.Description))
                {
                    transactionString += $" - {transaction.Description}";
                }
                Expenses.Add(transactionString);
                _expensesSum += exchangeCurrency(transaction.Sum, transaction.Currency);
            }
        }

        public void ClearSensitiveData()
        {
            
        }

        public void UpdateView()
        {
            _incomesSum = 0;
            _expensesSum = 0;

            _wallet = UserManager.CurrentWallet;

            Incomes = new ObservableCollection<string>();
            Expenses = new ObservableCollection<string>();
            foreach (var transaction in _transactionService.GetWalletLastMonthIncome(_wallet))
            {
                string transactionString = $"{transaction.DateTime} Sum: {transaction.Sum} ({transaction.Currency})";
                if (!String.IsNullOrEmpty(transaction.Description))
                {
                    transactionString += $" - {transaction.Description}";
                }
                Incomes.Add(transactionString);
                _incomesSum += exchangeCurrency(transaction.Sum, transaction.Currency);
            }
            foreach (var transaction in _transactionService.GetWalletLastMonthExpenses(_wallet))
            {
                string transactionString = $"{transaction.DateTime} Sum: {transaction.Sum} ({transaction.Currency})";
                if (!String.IsNullOrEmpty(transaction.Description))
                {
                    transactionString += $" - {transaction.Description}";
                }
                Expenses.Add(transactionString);
                _expensesSum += exchangeCurrency(transaction.Sum, transaction.Currency);
            }
        }

        private decimal exchangeCurrency(decimal sum, Currency currency)
        {
            if (currency == _wallet.Currency)
            {
                return sum;
            }
            if (currency == Currency.UAH)
            {
                if (_wallet.Currency == Currency.EUR)
                {
                    return sum / (decimal)33.45;
                }
                else if (_wallet.Currency == Currency.USD)
                {
                    return sum / 28;
                }
            }
            if (currency == Currency.EUR)
            {
                if (_wallet.Currency == Currency.UAH)
                {
                    return sum * (decimal)33.45;
                }
                else if (_wallet.Currency == Currency.USD)
                {
                    return sum * (decimal)1.2;
                }
            }
            if (currency == Currency.USD)
            {
                if (_wallet.Currency == Currency.UAH)
                {
                    return sum * 28;
                }
                else if (_wallet.Currency == Currency.EUR)
                {
                    return sum / (decimal)1.2;
                }
            }
            return sum;
        }
    }
}
