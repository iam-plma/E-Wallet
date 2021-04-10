using EWalletWPF.Navigation;
using Prism.Commands;
using Prism.Mvvm;
using Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EWalletWPF.Categories;

namespace EWalletWPF.Wallets
{
    public class WalletsViewModel : BindableBase, INotifyPropertyChanged, INavigatable<WalletsNavigatableTypes>
    {
        private WalletService _service;
        private WalletDetailsViewModel _currentWallet;
        private Action _gotoAddWallet;
        private Action _gotoCategories;
        public static ObservableCollection<WalletDetailsViewModel> Wallets { get; set; }
        public DelegateCommand AddWalletCommand { get; }
        public DelegateCommand CategoriesCommand { get; }
        public DelegateCommand QuitCommand { get; }

        public WalletDetailsViewModel CurrentWallet
        {
            get
            {
                return _currentWallet;
            }
            set
            {
                _currentWallet = value;
                RaisePropertyChanged();
            }
        }
        public WalletsNavigatableTypes Type
        {
            get
            {
                return WalletsNavigatableTypes.MainWallet;
            }
        }
        public WalletsViewModel(Action gotoAddWallet, Action gotoCategories)
        {
            _service = new WalletService();
            Wallets = new ObservableCollection<WalletDetailsViewModel>();
            foreach (var wallet in _service.GetWallets())
            {
                Wallets.Add(new WalletDetailsViewModel(wallet));
            }
            _gotoAddWallet = new Action(gotoAddWallet);
            AddWalletCommand = new DelegateCommand(_gotoAddWallet);
            _gotoCategories = new Action(gotoCategories);
            CategoriesCommand = new DelegateCommand(_gotoCategories);
            QuitCommand = new DelegateCommand(() => Environment.Exit(0));
        }
        public void ClearSensitiveData()
        {

        }
        public event PropertyChangedEventHandler PropertyChanged1;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged1?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateView()
        {
            _service = new WalletService();
            Wallets = new ObservableCollection<WalletDetailsViewModel>();
            foreach (var wallet in _service.GetWallets())
            {
                Wallets.Add(new WalletDetailsViewModel(wallet));
            }
        }
    }
}
