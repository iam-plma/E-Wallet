using System;
using EWalletWPF.Navigation;

namespace EWalletWPF.Transactions
{
    class BasicTransactionViewModel : NavigationBase<TransactionsNavigatableTypes>, INavigatable<WalletsNavigatableTypes>
    {
        private Action _gotoWallets;
        public BasicTransactionViewModel(Action gotoWallets)
        {
            _gotoWallets = gotoWallets;
            Navigate(TransactionsNavigatableTypes.MainTransaction);
        }

        protected override INavigatable<TransactionsNavigatableTypes> CreateViewModel(TransactionsNavigatableTypes type)
        {
            if (type == TransactionsNavigatableTypes.MainTransaction)
            {
                return new TransactionViewModel(() => Navigate(TransactionsNavigatableTypes.AddTransaction), _gotoWallets);
            }
            else
            {
                return new TransactionAddViewModel(() => Navigate(TransactionsNavigatableTypes.MainTransaction));
            }
        }

        public WalletsNavigatableTypes Type
        {
            get
            {
                return WalletsNavigatableTypes.Transactions;
            }
        }

        public void ClearSensitiveData()
        {
            CurrentViewModel.UpdateView();
            CurrentViewModel.ClearSensitiveData();
        }
        public void UpdateView()
        {
        }
    }
}
