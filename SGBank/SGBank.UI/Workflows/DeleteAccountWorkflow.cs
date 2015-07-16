using System;
using System.Linq;
using SGBank.Data;
using SGBank.Models;

namespace SGBank.UI.Workflows
{
    internal class DeleteAccountWorkflow
    {
        public void Execute()
        {
            var repo = new AccountRepository();
            var accounts = repo.GetAllAcounts();

            var account = GetAccountToDelete(repo);
            RemainingBalance(account);

            var accountToRemove = accounts.First(a => a.AccountNumber == account.AccountNumber);
            var success = accounts.Remove(accountToRemove);

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
            var readLine = Console.ReadLine();
            if (readLine != null)
                switch (readLine.ToUpper())
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
            Account account;
            bool delete = false;
            do
            {
                Console.WriteLine("\nPlease enter account number to delete: ");
                var accountNumber = Console.ReadLine();

                account = repo.GetAccount(accountNumber);
                Console.WriteLine("\nIs this the correct account to delete? (Y or N) Customer Name: {0} {1}",
                    account.FirstName, account.LastName);
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    var input = readLine.ToUpper();

                    switch (input)
                    {
                        case "Y":
                            delete = true;
                            break;
                        case "N":
                            break;
                        default:
                            Console.WriteLine("Invalid response, please try again.");
                            break;
                    }
                }
            } while (!delete);
            return account;
        }
    }
}