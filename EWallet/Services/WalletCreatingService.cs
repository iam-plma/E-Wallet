using DataStorage;
using Models.Users;
using Models.Wallets;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class WalletCreatingService
    {
        private FileDataStorage<DBWallet> _walletStorage = new FileDataStorage<DBWallet>();
        private FileDataStorage<DBUser> _userStorage = new FileDataStorage<DBUser>();

        public async Task<bool> CreateWalletAsync(NewWallet newWallet)
        {
            if (String.IsNullOrWhiteSpace(newWallet.Label))
                throw new ArgumentException("Label is Empty");

            var dbWallet = new DBWallet(newWallet.Label, newWallet.Description, newWallet.Balance, newWallet.Currency);
            for(int i = 0; i < newWallet.Categories.Count; i++)
            {
                dbWallet.CategoryGuids.Add(Guid.Parse(newWallet.Categories[i].FileName));
            }

            var users = await _userStorage.GetAllAsync();
            var dbUser = users.FirstOrDefault(user => user.Login == UserManager.Login);
            dbUser.AddWallet(dbWallet.Guid);

            await _walletStorage.AddOrUpdateAsync(dbWallet);
            await _userStorage.AddOrUpdateAsync(dbUser);

            return true;
        }

        public async Task<bool> UpdateWalletAsync(Wallet walletToEdit)
        {
            if (String.IsNullOrWhiteSpace(walletToEdit.Label))
                walletToEdit.Label = "";

            var wallets = await _walletStorage.GetAllAsync();
            var newDBWallet = new DBWallet(walletToEdit.Label, walletToEdit.Description, walletToEdit.Balance, walletToEdit.Currency, walletToEdit.FileName);

            await _walletStorage.AddOrUpdateAsync(newDBWallet);

            return true;
        }

        public async Task<bool> DeleteWalletAsync(Wallet walletToDelete)
        {
            if (String.IsNullOrWhiteSpace(walletToDelete.Label))
                throw new ArgumentException("Label is Empty");

            var wallets = await _walletStorage.GetAllAsync();
            var dbWallet = wallets.FirstOrDefault(wallet => wallet.FileName == walletToDelete.FileName);

            var users = await _userStorage.GetAllAsync();
            var dbUser = users.FirstOrDefault(user => user.Login == UserManager.Login);
            dbUser.DeleteWallet(Guid.Parse(dbWallet.FileName));

            if (dbWallet != null)
                _walletStorage.DeleteAsync(dbWallet.FileName);

            await _userStorage.AddOrUpdateAsync(dbUser);
            return true;
        }
    }
}
