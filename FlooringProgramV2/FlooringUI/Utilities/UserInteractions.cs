using System;
using FlooringBLL;

namespace FlooringUI.Utilities
{
    internal class UserInteractions
    {
        public static int PromptForChoice(string message, int lowerBound, int upperBound)
        {
            var validInput = false;
            var output = 0;

            while (!validInput)
            {
                Console.Write(message);
                validInput = int.TryParse(Console.ReadLine(), out output);

                if (!validInput)
                {
                    Console.WriteLine("That is not a valid choice");
                }
                else
                {
                    if (output < lowerBound || output > upperBound)
                    {
                        validInput = false;
                        Console.WriteLine("Choose an option {0}-{1}", lowerBound, upperBound);
                    }
                }
            }

            return output;
        }

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
                Console.WriteLine(message);
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

        public static DateTime PromptForDate(string message)
        {
            var validInput = false;
            var output = new DateTime();

            while (!validInput)
            {
                Console.Write(message);
                validInput = DateTime.TryParse(Console.ReadLine(), out output);

                if (!validInput)
                {
                    Console.WriteLine("That is not a valid date");
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

            while (!validInput)
            {
                Console.Write(message);
                var input = Console.ReadLine();

                if (mode == "Edit")
                {
                    if (output == 0)
                    {
                        var split = message.Split("(".ToCharArray());
                        var split2 = split[1].Split(")".ToCharArray());
                        output = decimal.Parse(split2[0]);
                    }

                    return output;
                }

                validInput = decimal.TryParse(input, out output);

                if (!validInput)
                {
                    Console.WriteLine("That is not a valid decimal!");
                }
            }

            return output;
        }

        internal static int PromptForInt(string message)
        {
            var validInput = false;
            var output = 0;

            while (!validInput)
            {
                Console.Write(message);
                validInput = int.TryParse(Console.ReadLine(), out output);

                if (!validInput)
                {
                    Console.WriteLine("That is not a valid number!");
                }
            }

            return output;
        }

        //public static RequestOrder PromptForValidOrder()
        //{
        //    bool validInput = false;
        //    string output = "";
        //    var ops = OperationsFactory.CreateOrderOperations(); ;
        //    var result = new Response<Order>();
        //    var request = new RequestOrder();

        //    while (!validInput)
        //    {
        //        var orderDate = PromptForDate("Enter order date: ");
        //        var orderNumber = PromptForInt("Enter order number: ");

        //        result = ops.GetOrder(orderDate, orderNumber);

        //        if (result.Success)
        //        {
        //            validInput = true;
        //            request.OrderDate = orderDate;
        //            request.Order = result.Data;
        //        }
        //        else
        //        {
        //            Console.WriteLine("That order does not exist!");
        //        }
        //    }

        //    return request;
        //}

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
                Console.WriteLine(message);
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