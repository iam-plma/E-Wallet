using DataStorage;
using Models.Users;
using Models.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class WalletService
    {
        private FileDataStorage<DBWallet> _walletStorage = new FileDataStorage<DBWallet>();
        private FileDataStorage<DBUser> _userStorage = new FileDataStorage<DBUser>();
        public static List<Wallet> Wallets = new List<Wallet>();

        public WalletService()
        {
        }

        public List<Wallet> GetWallets()
        {
            Task<List<Wallet>> task = Task.Run<List<Wallet>>(async () => await GetCurrentUserWalletsAsync());
            return task.Result;
        }

        public async Task<List<Wallet>> GetCurrentUserWalletsAsync()
        {
            var users = await _userStorage.GetAllAsync();
            var dbUser = users.FirstOrDefault(user => user.Login == UserManager.Login);

            List<string> walletsFileNames = new List<string>();
            foreach (Guid guid in dbUser.WalletsGuids)
                walletsFileNames.Add(guid.ToString("N"));

            if (walletsFileNames.Count == 0)
                return new List<Wallet>();

            List<Wallet> walletsResult = new List<Wallet>();
            var wallets = await _walletStorage.GetAllAsync();

            foreach (string fileName in walletsFileNames)
            {
                DBWallet tempWallet = wallets.FirstOrDefault(wallet => wallet.FileName == fileName);
                Wallet wallet = new Wallet()
                {
                    Label = tempWallet.Label,
                    Description = tempWallet.Description,
                    Balance = tempWallet.Balance,
                    Currency = tempWallet.Currency,
                    FileName = tempWallet.FileName
                };
                walletsResult.Add(wallet);
            }

            return walletsResult;


        }
    }
}
