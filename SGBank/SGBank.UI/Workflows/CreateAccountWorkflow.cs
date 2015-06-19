using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.UI.Workflows
{
    class CreateAccountWorkflow
    {
        public void Execute()
        {   var repo = new AccountRepository();
            List<Account> accounts = repo.GetAllAcounts();

            int acctNumber = GetNewAccountNumber(accounts);
            Account newAccount = GetCustomerInformation(acctNumber);
            accounts.Add(newAccount);
            DisplayNewAccount(newAccount);
            repo.WriteNewAccount(accounts);

            Console.ReadLine();
        }

        private void DisplayNewAccount(Account newAccount)
        {
            Console.WriteLine("We have created your new account!\n");
            Console.WriteLine("Customer name {1}, {0}.", newAccount.FirstName, newAccount.LastName);
            Console.WriteLine("New account number: {0}",newAccount.AccountNumber);
            Console.WriteLine("Account balance: {0}\n", newAccount.Balance);
        }

        private int GetNewAccountNumber(List<Account> accounts)
        {
            var accountNumbers = from a in accounts
                select a.AccountNumber;
            var maxAccount = accountNumbers.Max();

            int maxInt;
            Int32.TryParse(maxAccount, out maxInt);
            return maxInt + 1;
        }

        private Account GetCustomerInformation(int accountNumber)
        {
            Console.WriteLine("\nEnter customer first name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("\nEnter customer last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("\nEnter initial deposit amount: ");
            decimal balance;
            Decimal.TryParse(Console.ReadLine(), out balance);

            var accountNumberString = accountNumber.ToString();

            var account = new Account();
            account.FirstName = firstName;
            account.LastName = lastName;
            account.Balance = balance;
            account.AccountNumber = accountNumberString;

            return account;
        }
    }
}
