using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.Data
{
    public class AccountRepository
    {
        private const string FilePath = @"DataFiles\Bank.txt";

        public Account GetAccount(string accountNumber)
        {
            List<Account> allAccounts = GetAllAcounts();

            foreach (var account in allAccounts)
            {
                if (account.AccountNumber == accountNumber)
                    return account;
            }

            return null;
        }

        public List<Account> GetAllAcounts()
        {
            List<Account> accounts = new List<Account>();

            var reader = File.ReadAllLines(FilePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var account = new Account();

                account.AccountNumber = columns[0];
                account.FirstName = columns[1];
                account.LastName = columns[2];
                account.Balance = decimal.Parse(columns[3]);

                accounts.Add(account);
            }

            return accounts;
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
                    writer.WriteLine("{0},{1},{2},{3}", account.AccountNumber, account.FirstName, account.LastName, account.Balance);
                }
            }
        }
    }
}
