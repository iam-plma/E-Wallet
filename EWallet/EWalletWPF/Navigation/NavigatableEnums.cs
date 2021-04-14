namespace EWalletWPF.Navigation
{
    public enum AuthNavigatableTypes
    {
        SignIn,
        SignUp
    }

    public enum MainNavigatableTypes
    {
        Auth,
        Wallets
    }

    public enum WalletsNavigatableTypes
    {
        MainWallet,
        AddWallet,
        Categories,
        Transactions
    }

    public enum CategoriesNavigatableTypes
    {
        MainCategory,
        AddCategory
    }

    public enum TransactionsNavigatableTypes
    {
        MainTransaction,
        AddTransaction
    }
}
