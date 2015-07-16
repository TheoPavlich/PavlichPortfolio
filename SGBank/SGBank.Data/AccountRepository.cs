using System.Collections.Generic;
using System.IO;
using System.Linq;
using SGBank.Models;

namespace SGBank.Data
{
    public class AccountRepository
    {
        private const string FilePath = @"DataFiles\Bank.txt";

        public Account GetAccount(string accountNumber)
        {
            var allAccounts = GetAllAcounts();

            return allAccounts.FirstOrDefault(account => account.AccountNumber == accountNumber);
        }

        public List<Account> GetAllAcounts()
        {
            var accounts = new List<Account>();

            var reader = File.ReadAllLines(FilePath);

            for (var i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var account = new Account
                {
                    AccountNumber = columns[0],
                    FirstName = columns[1],
                    LastName = columns[2],
                    Balance = decimal.Parse(columns[3])
                };


                accounts.Add(account);
            }

            return accounts;
        }

        public void WriteNewAccount(List<Account> accounts)
        {
            OverwriteFile(accounts);
        }

        public void DeleteAccount(List<Account> accounts)
        {
            OverwriteFile(accounts);
        }

        public void UpdateAccount(Account accountToUpdate)
        {
            var allAccounts = GetAllAcounts();

            var existingAccount = allAccounts.First(a => a.AccountNumber == accountToUpdate.AccountNumber);
            existingAccount.Balance = accountToUpdate.Balance;
            existingAccount.FirstName = accountToUpdate.FirstName;
            existingAccount.LastName = accountToUpdate.LastName;

            OverwriteFile(allAccounts);
        }

        private void OverwriteFile(List<Account> allAccounts)
        {
            File.Delete(FilePath);

            using (var writer = File.CreateText(FilePath))
            {
                writer.WriteLine("AccountNumber,FirstName,LastName,Balance");

                foreach (var account in allAccounts)
                {
                    writer.WriteLine("{0},{1},{2},{3}", account.AccountNumber, account.FirstName, account.LastName,
                        account.Balance);
                }
            }
        }
    }
}