using System;
using EWalletWPF.Navigation;

namespace EWalletWPF.Wallets
{
    class BasicWalletsViewModel : NavigationBase<WalletsNavigatableTypes>, INavigatable<MainNavigatableTypes>
    {
        public BasicWalletsViewModel()
        {     
            Navigate(WalletsNavigatableTypes.MainWallet);
        }

        protected override INavigatable<WalletsNavigatableTypes> CreateViewModel(WalletsNavigatableTypes type)
        {
            if (type == WalletsNavigatableTypes.MainWallet)
            {
                return new WalletsViewModel(() => Navigate(WalletsNavigatableTypes.AddWallet));
            }
            else
            {
                return new WalletAddViewModel(() => Navigate(WalletsNavigatableTypes.MainWallet));
            }
        }

        public MainNavigatableTypes Type
        {
            get
            {
                return MainNavigatableTypes.Wallets;
            }
        }

        public void ClearSensitiveData()
        {
            CurrentViewModel.ClearSensitiveData();
        }
        public void UpdateView()
        {

        }
    }
}
