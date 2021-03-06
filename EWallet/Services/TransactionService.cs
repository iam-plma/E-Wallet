using DataStorage;
using Models.Transactions;
using Models.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TransactionService
    {
        private FileDataStorage<DBWallet> _walletStorage = new FileDataStorage<DBWallet>();
        private FileDataStorage<DBTransaction> _transactionStorage = new FileDataStorage<DBTransaction>();

        public TransactionService()
        {
        }

        public List<Transaction> GetWalletTransactions(Wallet wallet)
        {
            Task<List<Transaction>> task = Task.Run<List<Transaction>>(async () => await GetWalletTransactionsAsync(wallet));
            return task.Result;
        }

        public List<Transaction> GetWalletLastMonthIncome(Wallet wallet)
        {
            Task<List<Transaction>> task = Task.Run<List<Transaction>>(async () => await LastMonthStatsAsync(wallet, true));
            return task.Result;
        }
        public List<Transaction> GetWalletLastMonthExpenses(Wallet wallet)
        {
            Task<List<Transaction>> task = Task.Run<List<Transaction>>(async () => await LastMonthStatsAsync(wallet, false));
            return task.Result;
        }

        private async Task<List<Transaction>> GetWalletTransactionsAsync(Wallet walletToParse)
        {
            var wallets = await _walletStorage.GetAllAsync();
            var dbWallet = wallets.FirstOrDefault(wallet => wallet.FileName == walletToParse.FileName);

            List<string> transactionsFileNames = new List<string>();
            foreach (Guid guid in dbWallet.TransactionGuids)
                transactionsFileNames.Add(guid.ToString("N"));

            if (transactionsFileNames.Count == 0)
                return new List<Transaction>();

            List<Transaction> transactionsResult = new List<Transaction>();
            var transactions = await _transactionStorage.GetAllAsync();

            foreach (string fileName in transactionsFileNames)
            {
                DBTransaction tempTransaction = transactions.FirstOrDefault(transaction => transaction.FileName == fileName);
                Transaction transaction= new Transaction()
                {
                    DateTime = tempTransaction.DateTime,
                    Description = tempTransaction.Description,
                    Sum = tempTransaction.Sum,
                    Currency = tempTransaction.Currency,
                    FileName = tempTransaction.FileName
                };
                transactionsResult.Add(transaction);
            }
            return transactionsResult;
        }
        
        private async Task<List<Transaction>> LastMonthStatsAsync(Wallet walletToParse, bool income)
        {
            var wallets = await _walletStorage.GetAllAsync();
            var dbWallet = wallets.FirstOrDefault(wallet => wallet.FileName == walletToParse.FileName);

            List<string> transactionsFileNames = new List<string>();
            foreach (Guid guid in dbWallet.TransactionGuids)
                transactionsFileNames.Add(guid.ToString("N"));

            if (transactionsFileNames.Count == 0)
                return new List<Transaction>();

            List<Transaction> transactionsResult = new List<Transaction>();
            var transactions = await _transactionStorage.GetAllAsync();

            foreach (string fileName in transactionsFileNames)
            {
                DBTransaction tempTransaction = transactions.FirstOrDefault(transaction => transaction.FileName == fileName);
                Transaction transaction = new Transaction()
                {
                    DateTime = tempTransaction.DateTime,
                    Description = tempTransaction.Description,
                    Sum = tempTransaction.Sum,
                    Currency = tempTransaction.Currency,
                    FileName = tempTransaction.FileName
                };
                DateTime month = new DateTime(DateTime.Today.Year, DateTime.Today.Month - 1, DateTime.Today.Day);
                if(transaction.DateTime >= month && transaction.DateTime <= DateTime.Today)
                {
                    if (income)
                    {
                        if (transaction.Sum >= 0)
                            transactionsResult.Add(transaction);
                    }
                    else if (!income)
                    {
                        if (transaction.Sum <= 0)
                            transactionsResult.Add(transaction);
                    }
                }
            }
            return transactionsResult;
        }

    }
}
