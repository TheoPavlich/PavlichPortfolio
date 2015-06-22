using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringUI.Workflows
{
    class MainMenu
    {
        public void Execute()
        {
            string input;
            do
            {
                input = PrintMainMenu();
                ProcessUserChoice(input);
            } while (input != "5");
        }

        private void ProcessUserChoice(string input)
        {
            switch (input)
            {
                case "1":
                    DisplayOrder display = new DisplayOrder();
                    display.Execute();
                    break;
                case "2":
                    AddOrder add = new AddOrder();
                    add.Execute();
                    break;
                case "3":
                    EditOrder edit = new EditOrder();
                    edit.Execute();
                    break;
                case "4":
                    RemoveOrder remove = new RemoveOrder();
                    remove.Execute();
                    break;
                case "5":
                    Console.WriteLine("\nThank you. Goodbye.");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("\nNot a valid selection. Press enter to try again.");
                    Console.ReadLine();
                    break;
            }
        }

        private string PrintMainMenu()
        {
            Console.Clear();
            Console.WriteLine("*******Flooring Program*******\n*\n*\n* 1. Display Order\n* 2. Add an Order" +
                              "\n* 3. Edit an Order\n* 4. Remove an Order\n* 5. Quit\n*\n");
            Console.WriteLine("Please enter your choice: \n");
            string input = Console.ReadLine();
            return input;
        }
    }
}
