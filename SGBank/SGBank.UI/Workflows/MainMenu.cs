using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class MainMenu
    {
        public void Execute()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("************ Welcome to SG Bank ****************");
                Console.WriteLine("================================================");
                Console.WriteLine();
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Delete Account");
                Console.WriteLine("3. Lookup Account");
                Console.WriteLine("\n(Q) to Quit");

                Console.Write("\n\nEnter choice: ");
                string input = Console.ReadLine();

                if (input.ToUpper() == "Q")
                    break;

                ProcessUserChoice(input);
            } while (true);
        }

        private void ProcessUserChoice(string input)
        {
            switch (input)
            {
                case "1":
                    var createAccount = new CreateAccountWorkflow();
                    createAccount.Execute();
                    break;
                case "2":
                    var deleteAccount = new DeleteAccountWorkflow();
                    deleteAccount.Execute();
                    break;
                case "3":
                    var lookupMenu = new LookupMenu();
                    lookupMenu.Execute();
                    break;
            }
        }
    }
}
