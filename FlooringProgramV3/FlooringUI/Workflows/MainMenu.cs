using System;

namespace FlooringUI.Workflows
{
    internal class MainMenu
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
                    var display = new DisplayOrder();
                    display.Execute();
                    break;
                case "2":
                    var add = new AddOrder();
                    add.Execute();
                    break;
                case "3":
                    var edit = new EditOrder();
                    edit.Execute();
                    break;
                case "4":
                    var remove = new RemoveOrder();
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
            var input = Console.ReadLine();
            return input;
        }
    }
}