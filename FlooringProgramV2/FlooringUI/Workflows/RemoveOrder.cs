using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Flooring.Data;
using Flooring.Models;
using FlooringUI.Utilities;

namespace FlooringUI.Workflows
{
    internal class RemoveOrder
    {
        public void Execute()
        {

            string orderFile = GetOrderDateFromUser();
            List<Order> orders = FindOrderFile(orderFile);
            if (orders.Count != 0)
            {
                bool orderExists = false;
                while (!orderExists)
                {
                Console.WriteLine("Select order number to remove.");
                string userChoice = Console.ReadLine();

                if (userChoice == "0") return;

                var orderNumbers = from o in orders select o.OrderNumber;
                
                    if (orderNumbers.Contains(userChoice))
                    {
                        orderExists = true;
                        string confirm =
                            UserInteractions.PromptForConfirmation("Would you like to remove this order (Y or N)?");
                        if (confirm == "Y")
                        {
                            RemoveSelectedOrder(userChoice, orders, orderFile.Substring(17, 8));
                            UserInteractions.PromptToContinue();
                        }
                        else
                        {
                            return;
                        }
                    }
                    Console.WriteLine("Order does not exist, please try again.");
                }
            }
        }

        public string GetOrderDateFromUser()
        {

            Console.Clear();

            Console.Write("Enter an order date (MMddyyyy): ");
            string orderDate = Console.ReadLine();

            return @"DataFiles\Orders_" + orderDate + ".txt";
        }

        private List<Order> FindOrderFile(string orderFile)
        {
            List<Order> orders = new List<Order>();
            if (File.Exists(orderFile))
            {
                Console.WriteLine("\n*****Order Information*****\n");

                var repo = new OrderRepository();
                orders = repo.GetAllItems("Orders_" + orderFile.Substring(17, 8));
                PrintOrderDetails(orders, orderFile.Substring(17, 8));
            }
            else
            {
                Console.WriteLine("No order exists on that date.");
                UserInteractions.PromptToContinue();
            }
            return orders;
        }

        public void PrintOrderDetails(List<Order> orders, string date)
        {
            Console.WriteLine("Orders for " + date + ":\n");
            foreach (var order in orders)
            {
                Console.WriteLine("Order Number: {0}", order.OrderNumber);
                Console.WriteLine("Name: {0} {1}", order.FirstName, order.LastName);
                Console.WriteLine("Product Type: {0}", order.ProductType);
                Console.WriteLine("Total: {0:C}\n", order.Total);
            }
        }

        private void RemoveSelectedOrder(string userChoice, List<Order> orders, string orderFile)
        {

            Order order = orders.First(o => o.OrderNumber == userChoice);

            orders.Remove(order);

            var ops = new OrderRepository();

            ops.DeleteOrder(orders, orderFile);
        }
    }
}