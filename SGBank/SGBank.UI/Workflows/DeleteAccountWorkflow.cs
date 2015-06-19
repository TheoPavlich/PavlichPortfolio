using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.UI.Workflows
{
    class DeleteAccountWorkflow
    {
        public void Execute()
        {
            var repo = new AccountRepository();
            List<Account> accounts = repo.GetAllAcounts();

            Account account = GetAccountToDelete(repo);
            RemainingBalance(account);

            var accountToRemove = accounts.First(a => a.AccountNumber == account.AccountNumber);
            bool success = accounts.Remove(accountToRemove);

            repo.DeleteAccount(accounts);
            if (success)
            {
                Console.WriteLine("Account has been deleted. Press enter to return to menu.");
            }
            Console.ReadLine();

        }

        private void RemainingBalance(Account account)
        {
            Console.WriteLine("\nAccount has remaining balance of {0:C}. " +
                              "Cut check or donate to DeadFish Foundation for the Homeless?  (C or D).", account.Balance);
            switch (Console.ReadLine().ToUpper())
            {
                case "C":
                    Console.WriteLine("Jerk.\n");
                    break;
                case "D":
                    Console.WriteLine("You are so generous sir/madam/comrade.\n");
                    break;
            }
        }

        private Account GetAccountToDelete(AccountRepository repo)
        {
            bool delete = true;
            do
            {
                Console.WriteLine("\nPlease enter account number to delete: ");
                string accountNumber = Console.ReadLine();
                
                Account account = repo.GetAccount(accountNumber);
                Console.WriteLine("\nIs this the correct account to delete? (Y or N) Customer Name: {0} {1}",
                    account.FirstName, account.LastName);
                string input = Console.ReadLine().ToUpper();
                
                switch (input)
                {
                    case "Y":
                        
                    case "N":
                        delete = false;
                        break;
                    default:
                        Console.WriteLine("Invalid response, please try again.");
                        delete = false;
                        break;

                }
                return account;
            } while (!delete);

        }
    }
}
