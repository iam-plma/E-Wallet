using DataStorage;
using Models.Wallets;
using Models.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TransactionCreatingService
    {
        private FileDataStorage<DBWallet> _walletStorage = new FileDataStorage<DBWallet>();
        private FileDataStorage<DBTransaction> _transactionStorage = new FileDataStorage<DBTransaction>();

        public async Task<bool> CreateTransactionAsync(NewTransaction newTransaction, Wallet walletToEdit)
        {
            var dbTransaction = new DBTransaction(newTransaction.DateTime, newTransaction.Description, 
                newTransaction.Sum, newTransaction.Currency);

            var wallets = await _walletStorage.GetAllAsync();
            var dbWallet = wallets.FirstOrDefault(wallet => wallet.FileName == walletToEdit.FileName);
            //dbWallet.AddTransaction(dbTransaction.Guid);
            dbWallet.AddTransaction(dbTransaction);

            await _transactionStorage.AddOrUpdateAsync(dbTransaction);
            await _walletStorage.AddOrUpdateAsync(dbWallet);

            return true;
        }

        public async Task<bool> DeleteTransactionAsync(Transaction transactionToDelete, Wallet walletToEdit)
        {
            var transactions = await _transactionStorage.GetAllAsync();
            var dbTransaction = transactions.FirstOrDefault(transaction => transaction.FileName == transactionToDelete.FileName);

            var wallets = await _walletStorage.GetAllAsync();
            var dbWallet = wallets.FirstOrDefault(wallet => wallet.FileName == walletToEdit.FileName);
            //dbWallet.DeleteTransaction(Guid.Parse(dbTransaction.FileName));
            dbWallet.DeleteTransaction(dbTransaction);

            if (dbTransaction != null)
                _transactionStorage.DeleteAsync(dbTransaction.FileName);

            await _walletStorage.AddOrUpdateAsync(dbWallet);
            return true;
        }

        public async Task<bool> UpdateTransactionAsync(Transaction transactionToUpdate, Wallet walletToEdit, decimal sumDifference, 
            Currency oldCurrency)
        {
            var transactions = await _transactionStorage.GetAllAsync();
            var dbTransaction = transactions.FirstOrDefault(transaction => transaction.FileName == transactionToUpdate.FileName);
            dbTransaction = new DBTransaction(transactionToUpdate.DateTime, transactionToUpdate.Description, transactionToUpdate.Sum,
                transactionToUpdate.Currency, transactionToUpdate.FileName);
            //update wallet balance

            var wallets = await _walletStorage.GetAllAsync();
            var dbWallet = wallets.FirstOrDefault(wallet => wallet.FileName == walletToEdit.FileName);

            if(sumDifference != 0)
                dbWallet.UpdateBalance(sumDifference, dbTransaction.Currency);
            if(oldCurrency != transactionToUpdate.Currency)
                dbWallet.ChangeTransactionCurrency(transactionToUpdate.Sum, oldCurrency, transactionToUpdate.Currency);
            
            await _walletStorage.AddOrUpdateAsync(dbWallet);
            await _transactionStorage.AddOrUpdateAsync(dbTransaction);

            return true;
        }
    }
}
