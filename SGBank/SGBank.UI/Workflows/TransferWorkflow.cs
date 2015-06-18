using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.BLL;
using SGBank.Models;
using SGBank.UI.Utilities;

namespace SGBank.UI.Workflows
{
    public class TransferWorkflow
    {
        public void Execute(Account currentAccount)
        {
            Account otherAccount = GetOtherAccount();
           
            decimal amount = GetTransferAmount();
            var ops = new AccountOperations();

            Account withdrawAccount=TransferDirection(currentAccount, otherAccount);
            Account depositAccount = new Account();

            if (currentAccount == withdrawAccount)
            {
                depositAccount = otherAccount;
            }
            else
            {
                depositAccount = currentAccount;
            }

            var depositRequest = new DepositRequest()
            {
                Account = depositAccount,
                DepositAmount = amount
            };

            var withdrawRequest = new WithdrawRequest()
            {
                Account = withdrawAccount,
                WithdrawAmount = amount
            };

            var depositResponse = ops.MakeDeposit(depositRequest);
            var withdrawResponse = ops.MakeWithdraw(withdrawRequest);

            if (depositResponse.Success && withdrawResponse.Success)
            {
                Console.Clear();
                Console.WriteLine("Deposited to account {0} from {2}. New Balance in {0}: {1:C}, new balance in {2}: {3:C}", depositResponse.Data.AccountNumber, depositResponse.Data.Balance, withdrawResponse.Data.AccountNumber,withdrawResponse.Data.Balance);
                UserInteractions.PressKeyToContinue();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("An Error Occured:  {0}", withdrawResponse.Message);
                UserInteractions.PressKeyToContinue();
            }


        }

        private Account TransferDirection(Account currentAccount, Account otherAccount)
        {
            do
            {
                Console.WriteLine(
                    "Is this a deposit to other account or a withdraw from other account? Enter \"D\" or \"W\"");
                string input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "D":
                        return currentAccount;
                    case "W":
                        return otherAccount;
                }
            } while (true);
        }

        private Account GetOtherAccount()
        {
            do
            {
                Console.Clear();
                Console.Write("Enter the account number to transfer money with: ");
                string input = Console.ReadLine();
                int thisAccountNumber;

                if (int.TryParse(input, out thisAccountNumber))
                {
                    var ops = new AccountOperations();
                    var response = ops.GetAccount(input);
                    Console.Clear();

                    if (response.Success)
                    {
                        return response.Data;
                    }
                }
                    

                Console.WriteLine("That was not a valid account number.  Press any key to continue...");
                Console.ReadKey();
            } while (true);
         }
        
        private decimal GetTransferAmount()
        {
            do
            {
                Console.Write("Enter a transfer amount: ");
                var input = Console.ReadLine();
                decimal amount;
                if (decimal.TryParse(input, out amount))
                {
                    return amount;
                }

                Console.WriteLine("That was not a valid amount.  Please enter in decimal format.");
                UserInteractions.PressKeyToContinue();
                Console.Clear();
            } while (true);
        }
    }
}
