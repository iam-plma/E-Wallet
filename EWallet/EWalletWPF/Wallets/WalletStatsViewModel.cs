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
        public DelegateCommand BackCommand { get; }
        public static ObservableCollection<string> Incomes { get; set; }
        public static ObservableCollection<string> Expenses { get; set; }

        public decimal Balance
        {
            get
            {
                return _wallet.Balance;
            }
            set
            {
                
            }
        }

        public WalletsNavigatableTypes Type
        {
            get { return WalletsNavigatableTypes.Stats; }
        }

        public WalletStatsViewModel(Action gotoWalletsMenu)
        {
            _wallet = UserManager.CurrentWallet;

            _gotoWalletsMenu = gotoWalletsMenu;
            BackCommand = new DelegateCommand(_gotoWalletsMenu);

            _transactionService = new TransactionService();
            Incomes = new ObservableCollection<string>();
            Expenses = new ObservableCollection<string>();
            foreach(var transaction in _transactionService.GetWalletLastMonthIncome(_wallet))
            {
                string transactionString = $"{transaction.DateTime} Sum:{transaction.Sum}{transaction.Currency}";
                if (!String.IsNullOrEmpty(transaction.Description))
                {
                    transactionString += $" - {transaction.Description}";
                }
                Incomes.Add(transactionString);
            }
            foreach (var transaction in _transactionService.GetWalletLastMonthExpenses(_wallet))
            {
                string transactionString = $"{transaction.DateTime} Sum:{transaction.Sum}{transaction.Currency}";
                if (!String.IsNullOrEmpty(transaction.Description))
                {
                    transactionString += $" - {transaction.Description}";
                }
                Expenses.Add(transactionString);
            }
        }

        public void ClearSensitiveData()
        {
            
        }

        public void UpdateView()
        {
            _wallet = UserManager.CurrentWallet;


            Incomes = new ObservableCollection<string>();
            Expenses = new ObservableCollection<string>();
            foreach (var transaction in _transactionService.GetWalletLastMonthIncome(_wallet))
            {
                string transactionString = $"{transaction.DateTime} Sum:{transaction.Sum}{transaction.Currency}";
                if (!String.IsNullOrEmpty(transaction.Description))
                {
                    transactionString += $" - {transaction.Description}";
                }
                Incomes.Add(transactionString);
            }
            foreach (var transaction in _transactionService.GetWalletLastMonthExpenses(_wallet))
            {
                string transactionString = $"{transaction.DateTime} Sum:{transaction.Sum}{transaction.Currency}";
                if (!String.IsNullOrEmpty(transaction.Description))
                {
                    transactionString += $" - {transaction.Description}";
                }
                Expenses.Add(transactionString);
            }
        }
    }
}
