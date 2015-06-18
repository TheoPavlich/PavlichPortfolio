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
    public class WithdrawWorkflow
    {
        public void Execute(Account account)
        {
            decimal amount = GetWithdrawAmount();
            var ops = new AccountOperations();
            var request = new WithdrawRequest()
            {
                Account = account,
                WithdrawAmount = amount
            };

            var response = ops.MakeWithdraw(request);

            if (response.Success)
            {
                Console.Clear();
                Console.WriteLine("Withraw to account {0}, New Balance: {1:C}", response.Data.AccountNumber, response.Data.Balance);
                UserInteractions.PressKeyToContinue();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("An Error Occured:  {0}", response.Message);
                UserInteractions.PressKeyToContinue();
            }


        }

        private decimal GetWithdrawAmount()
        {
            do
            {
                Console.Write("Enter a withdraw amount: ");
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
