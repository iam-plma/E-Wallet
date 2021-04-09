using Models.Wallets;
using Prism.Commands;
using Prism.Mvvm;
using Services;
using System;

namespace EWalletWPF.Wallets
{
    public class WalletDetailsViewModel : BindableBase
    {
        private Wallet _wallet;
        public DelegateCommand RefreshCommand { get; }
        public DelegateCommand DeleteWalletCommand { get; }
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
                _wallet.Currency = value;
                UpdateWallet();
                RaisePropertyChanged(nameof(DisplayName));
            }
        }
        public string DisplayName
        {
            get
            {
                return $"{_wallet.Label} ({_wallet.Balance} {_wallet.Currency})";
            }
        }
        public WalletDetailsViewModel(Wallet wallet)
        {
            _wallet = wallet;
            DeleteWalletCommand = new DelegateCommand(new Action(DeleteWallet));
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
    }
}
