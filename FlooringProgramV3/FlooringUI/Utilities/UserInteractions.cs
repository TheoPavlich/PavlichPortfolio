using System;
using FlooringBLL;

namespace FlooringUI.Utilities
{
    internal class UserInteractions
    {
        public static string PromptForValidState(string message)
        {
            var validInput = false;
            var output = "";
            var taxOperations = OperationsMode.CreateTaxOperations();

            while (!validInput)
            {
                Console.WriteLine(message);
                var readLine = Console.ReadLine();
                if (readLine != null) output = readLine.ToUpper();

                if (!taxOperations.IsValidState(output))
                {
                    Console.WriteLine("That is not a state we sell in.");
                }
                else
                {
                    validInput = true;
                }
            }

            return output;
        }

        public static string PromptForValidStateEdit(string message)
        
        {
            var validInput = false;
            var output = "";
            var taxOperations = OperationsMode.CreateTaxOperations();

            while (!validInput)
            {
                Console.Write(message);
                var readLine = Console.ReadLine();
                if (readLine != null) output = readLine.ToUpper();
                if (string.IsNullOrWhiteSpace(output))
                {
                    var split = message.Split("(".ToCharArray());
                    var split2 = split[1].Split(")".ToCharArray());
                    output = split2[0];
                    return output;
                }

                if (!taxOperations.IsValidState(output))
                {
                    Console.WriteLine("That is not a state we sell in.");
                }
                else
                {
                    validInput = true;
                }
            }
            return output;
        }

        public static void PromptToContinue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        public static string PromptForRequiredString(string message, string mode)
        {
            var validInput = false;
            var output = "";

            while (!validInput)
            {
                Console.Write(message);
                var readLine = Console.ReadLine();
                if (readLine != null) output = readLine.ToUpper();

                if (mode == "Edit")
                {
                    if (string.IsNullOrWhiteSpace(output))
                    {
                        var split = message.Split("(".ToCharArray());
                        var split2 = split[1].Split(")".ToCharArray());
                        output = split2[0];
                    }

                    return output;
                }
                if (string.IsNullOrEmpty(output))
                {
                    Console.WriteLine("Please enter some data.");
                }
                else
                {
                    validInput = true;
                }
            }

            return output;
        }

        public static decimal PromptForDecimal(string message, string mode)
        {
            var validInput = false;
            decimal output = 0;
            string input = "";

            while (!validInput)
            {
                Console.Write(message);
                input = Console.ReadLine();

                validInput = decimal.TryParse(input, out output);
                
                if (mode == "Edit")
                {
                    if (output == 0 && input == "") 
                    {
                        var split = message.Split("(".ToCharArray());
                        var split2 = split[1].Split(")".ToCharArray());
                        output = decimal.Parse(split2[0]);
                        return output;
                    }
                }

                if (!validInput)
                {
                    Console.WriteLine("That is not a valid decimal!");
                }
            }

            return output;
        }

        public static string PromptForConfirmation(string message)
        {
            var validInput = false;
            var output = "";

            while (!validInput)
            {
                Console.Write(message);
                var readLine = Console.ReadLine();
                if (readLine != null) output = readLine.ToUpper();


                if (string.IsNullOrEmpty(output))
                {
                    Console.WriteLine("Please make a selection.");
                }
                else
                {
                    output = output.Substring(0, 1).ToUpper();
                    if (output == "Y" || output == "N")
                        validInput = true;
                }
            }

            return output;
        }

        public static string PromptForValidProduct(string message, string mode)
        {
            var validInput = false;
            var output = "";
            var productOperations = OperationsMode.CreateOrderOperations();

            while (!validInput)
            {
                Console.Write(message);
                var readLine = Console.ReadLine();
                if (readLine != null) output = readLine.ToUpper();
                
                if (mode == "Edit")
                {
                    if (string.IsNullOrWhiteSpace(output))
                    {
                        var split = message.Split("(".ToCharArray());
                        var split2 = split[1].Split(")".ToCharArray());
                        output = split2[0];
                    }
                }

                if (!productOperations.IsValidProduct(output))
                {
                    Console.WriteLine("That is not a product we sell.");
                }
                else
                {
                    validInput = true;
                }
            }

            return output;
        }
    }
}