using EWalletWPF.Navigation;
using EWalletWPF.Categories;
using EWalletWPF.Transactions;

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
                return new WalletsViewModel(() => Navigate(WalletsNavigatableTypes.AddWallet), 
                    () => Navigate(WalletsNavigatableTypes.Categories), () => Navigate(WalletsNavigatableTypes.Transactions), 
                    () => Navigate(WalletsNavigatableTypes.Stats));
            }
            else if(type == WalletsNavigatableTypes.AddWallet)
            {
                return new WalletAddViewModel(() => Navigate(WalletsNavigatableTypes.MainWallet));
            }
            else if(type == WalletsNavigatableTypes.Categories)
            {
                 return new BasicCategoriesViewModel(() => Navigate(WalletsNavigatableTypes.MainWallet));
            }
            else if (type == WalletsNavigatableTypes.Stats)
            {
                return new WalletStatsViewModel(() => Navigate(WalletsNavigatableTypes.MainWallet));
            }
            else
            {
                return new BasicTransactionViewModel(() => Navigate(WalletsNavigatableTypes.MainWallet));
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
