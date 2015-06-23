using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data;
using Flooring.Models;

namespace FlooringUI.Workflows
{
    class DisplayOrder
    {
        public void Execute()
        {

            string orderFile = GetOrderDateFromUser();
            FindOrderFile(orderFile);


        }

        private void FindOrderFile(string orderFile)
        {
            if (File.Exists(orderFile))
            {
                Console.WriteLine("Order Information");
                Console.WriteLine("Order Date: {0}", orderFile.Substring(16, 6));
                var repo = new OrderRepository();
                List<Order> orders = repo.GetAllOrders(orderFile.Substring(16,6));
                PrintOrderDetails(orders);
            }
            else
            {
                Console.WriteLine("No order exists on that date. Press enter to return to main menu.");
            }
            Console.ReadLine();
        }

        public void PrintOrderDetails(List<Order> orders)
        {
            Console.Clear();


            foreach (var order in orders)
            {
                Console.WriteLine("First Name: {0}", order.FirstName);
                Console.WriteLine("Last Name: {0}", order.LastName);
                Console.WriteLine("Product Type: {0}", order.ProductType);
                Console.WriteLine("Total: {0}", order.Total);
            }

        }

        public string GetOrderDateFromUser()
        {
           // do
           // {
                Console.Clear();
                //string date = DateTime.Today.ToString("MMddyyy");

                Console.Write("Enter an order date (MMddyy): ");
                string orderDate = Console.ReadLine();

                return @"DataFiles\Orders_" + orderDate + ".txt";

                //} while (true);
                //foreach (var order in orders)
            }

            


        
    }
}
