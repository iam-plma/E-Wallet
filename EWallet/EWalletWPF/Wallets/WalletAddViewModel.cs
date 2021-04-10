using EWalletWPF.Navigation;
using Models.Wallets;
using Prism.Commands;
using Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace EWalletWPF.Wallets
{
    public class WalletAddViewModel : INavigatable<WalletsNavigatableTypes>, INotifyPropertyChanged
    {
        private NewWallet _newWallet = new NewWallet();
        private Action _gotoWalletsMenu;
        public DelegateCommand BackCommand { get; }
        public DelegateCommand CreateWalletCommand { get; }
        public WalletAddViewModel(Action gotoWalletsMenu)
        {
            CreateWalletCommand = new DelegateCommand(CreateWallet, IsCreateWalletEnabled);
            _gotoWalletsMenu = gotoWalletsMenu;
            BackCommand = new DelegateCommand(_gotoWalletsMenu);
        }
        public WalletsNavigatableTypes Type
        {
            get
            {
                return WalletsNavigatableTypes.AddWallet;
            }
        }

        public string Label
        {
            get
            {
                return _newWallet.Label;
            }
            set
            {
                if (_newWallet.Label != value)
                {
                    _newWallet.Label = value;
                    OnPropertyChanged();
                    CreateWalletCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Description
        {
            get
            {
                return _newWallet.Description;
            }
            set
            {
                if (_newWallet.Description != value)
                {
                    _newWallet.Description = value;
                    OnPropertyChanged();
                    CreateWalletCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public decimal Balance
        {
            get
            {
                return _newWallet.Balance;
            }
            set
            {
                if (_newWallet.Balance != value)
                {
                    _newWallet.Balance = value;
                    OnPropertyChanged();
                    CreateWalletCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public Currency Currency
        {
            get
            {
                return _newWallet.Currency;
            }
            set
            {
                if (_newWallet.Currency != value)
                {
                    _newWallet.Currency = value;
                    OnPropertyChanged();
                    CreateWalletCommand.RaiseCanExecuteChanged();
                }
            }
        }
        private async void CreateWallet()
        {
            var walletCreatingService = new WalletCreatingService();
            try
            {
                await walletCreatingService.CreateWalletAsync(_newWallet);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Create Wallet failed: {ex.Message}");
                return;
            }

            MessageBox.Show($"Wallet successfully created");
            _gotoWalletsMenu.Invoke();
        }

        private bool IsCreateWalletEnabled()
        {
            return !String.IsNullOrWhiteSpace(Label) && !String.IsNullOrWhiteSpace(Description) && (Currency == Currency.EUR || Currency == Currency.USD || Currency == Currency.UAH);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ClearSensitiveData()
        {
            _newWallet = new NewWallet();
        }

        public void UpdateView()
        {

        }
    }
}
