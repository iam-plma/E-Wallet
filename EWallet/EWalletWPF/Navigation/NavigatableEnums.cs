using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        AddWallet
    }
}
