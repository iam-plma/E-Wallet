using EWalletWPF.Navigation;
using System;

namespace EWalletWPF.Categories
{
    class BasicCategoriesViewModel : NavigationBase<CategoriesNavigatableTypes>, INavigatable<WalletsNavigatableTypes>
    {
        private Action _gotoWallets;
        public BasicCategoriesViewModel(Action gotoWallets)
        {
            _gotoWallets = gotoWallets;
            Navigate(CategoriesNavigatableTypes.MainCategory);
        }

        protected override INavigatable<CategoriesNavigatableTypes> CreateViewModel(CategoriesNavigatableTypes type)
        {
            if (type == CategoriesNavigatableTypes.MainCategory)
            {
                return new CategoriesViewModel(() => Navigate(CategoriesNavigatableTypes.AddCategory), _gotoWallets);
            }
            else
            {
                return new AddCategoryViewModel(() => Navigate(CategoriesNavigatableTypes.MainCategory));
            }
        }

        public WalletsNavigatableTypes Type
        {
            get
            {
                return WalletsNavigatableTypes.Categories;
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
