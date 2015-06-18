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
    public class DepositWorkflow
    {
        public void Execute(Account account)
        {
            decimal amount = GetDepositAmount();
            var ops = new AccountOperations();
            var request = new DepositRequest()
            {
                Account = account,
                DepositAmount = amount
            };

            var response = ops.MakeDeposit(request);

            if (response.Success)
            {
                Console.Clear();
                Console.WriteLine("Deposited to account {0}, New Balance: {1:C}", response.Data.AccountNumber, response.Data.Balance);
                UserInteractions.PressKeyToContinue();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("An Error Occured:  {0}", response.Message);
                UserInteractions.PressKeyToContinue();
            }


        }

        private decimal GetDepositAmount()
        {
            do
            {
                Console.Write("Enter a deposit amount: ");
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
