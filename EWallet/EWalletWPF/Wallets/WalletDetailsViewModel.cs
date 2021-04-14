using Models.Categories;
using Models.Wallets;
using Prism.Commands;
using Prism.Mvvm;
using Services;
using System;
using System.Collections.ObjectModel;

namespace EWalletWPF.Wallets
{
    public class WalletDetailsViewModel : BindableBase
    {
        private Wallet _wallet;
        private CategoryService _categoryService;
        private WalletsViewModel _ownerView;
        private Action _gotoTransactions;
        private Action _gotoStats;
        public static ObservableCollection<string> Categories { get; set; }
        public DelegateCommand DeleteWalletCommand { get; }
        public DelegateCommand TransactionsCommand { get; }
        public DelegateCommand StatsCommand { get; }
        public string Name
        {
            get
            {
                return _wallet.Label;
            }
            set
            {
                _wallet.Label = value;
                UpdateWallet();
                RaisePropertyChanged(nameof(DisplayName));
            }
        }

        public string Description
        {
            get
            {
                return _wallet.Description;
            }
            set
            {
                _wallet.Description = value;
                UpdateWallet();
            }
        }

        public decimal Balance
        {
            get
            {
                return _wallet.Balance;
            }
            set
            {
                _wallet.Balance = value;
                UpdateWallet();
                RaisePropertyChanged(nameof(DisplayName));
            }
        }

        public Currency Currency
        {
            get
            {
                return _wallet.Currency;
            }
            set
            {
                Currency tempCurrency = _wallet.Currency;
                _wallet.Currency = value;

                if (_wallet.Currency != tempCurrency)
                    ChangeCurrency(tempCurrency);

                UpdateWallet();
                RaisePropertyChanged(nameof(DisplayName));
            }
        }
        public Wallet Wallet
        {
            get
            {
                return _wallet;
            }
        }
        public string DisplayName
        {
            get
            {
                return $"{_wallet.Label} ({_wallet.Balance} {_wallet.Currency})";
            }
        }
        public string CategoryDisplayName
        {
            get
            {
                return $"{_wallet.Label} ({_wallet.Balance.ToString()} {_wallet.Currency})";
            }
        }

        public WalletDetailsViewModel(Wallet wallet, Action gotoTransactions, WalletsViewModel owner, Action gotoStats)
        {
            _wallet = wallet;
            DeleteWalletCommand = new DelegateCommand(new Action(DeleteWallet));

            _gotoTransactions = gotoTransactions;
            TransactionsCommand = new DelegateCommand(_gotoTransactions);

            _categoryService = new CategoryService();
            Categories = new ObservableCollection<string>();
            foreach(var category in _categoryService.GetCurrentWalletCategories(wallet))
            {
                Categories.Add($"{category.Label} - {category.Description}");
            }
            _ownerView = owner;

            _gotoStats = gotoStats;
            StatsCommand = new DelegateCommand(_gotoStats);
        }
        private async void DeleteWallet()
        {
            var creatingService = new WalletCreatingService();
            await creatingService.DeleteWalletAsync(_wallet);

            WalletsViewModel.Wallets.Remove(this);
        }
        private async void UpdateWallet()
        {
            var creatingService = new WalletCreatingService();
            await creatingService.UpdateWalletAsync(_wallet);
        }
        private void ChangeCurrency(Currency oldCurrency)
        {
            if (_wallet.Currency == Currency.UAH)
            {
                if (oldCurrency == Currency.EUR)
                {
                    Balance *= (decimal)33.45;
                }
                else if (oldCurrency == Currency.USD)
                {
                    Balance *= 28;
                }
                UpdateWallet();
                return;
            }
            if (_wallet.Currency == Currency.EUR)
            {
                if (oldCurrency == Currency.UAH)
                {
                    Balance /= (decimal)33.45;
                }
                else if (oldCurrency == Currency.USD)
                {
                    Balance /= (decimal)1.2;
                }

                UpdateWallet();
                return;
            }
            if (_wallet.Currency == Currency.USD)
            {
                if (oldCurrency == Currency.UAH)
                {
                    Balance /= 28;
                }
                else if (oldCurrency == Currency.EUR)
                {
                    Balance *= (decimal)1.2;
                }
                UpdateWallet();
                return;
            }
        }
    }
}
