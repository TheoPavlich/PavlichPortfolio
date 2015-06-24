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
                Console.WriteLine("\n*****Order Information*****\n");
                
                var repo = new OrderRepository();
                List<Order> orders = repo.GetAllItems("Orders_"+orderFile.Substring(17,8));
                PrintOrderDetails(orders, orderFile.Substring(17, 8));
            }
            else
            {
                Console.WriteLine("No order exists on that date. Press enter to return to main menu.");
            }
            Console.ReadLine();
        }

        public void PrintOrderDetails(List<Order> orders, string date)
        {
            Console.WriteLine("Orders for "+ date + ":\n");
            foreach (var order in orders)
            {
                
                Console.WriteLine("Name: {0} {1}", order.FirstName,order.LastName);
                Console.WriteLine("Product Type: {0}", order.ProductType);
                Console.WriteLine("Total: {0:C}\n", order.Total);
            }

        }

        public string GetOrderDateFromUser()
        {
           // do
           // {
                Console.Clear();
                //string date = DateTime.Today.ToString("MMddyyy");

                Console.Write("Enter an order date (MMddyyyy): ");
                string orderDate = Console.ReadLine();

                return @"DataFiles\Orders_" + orderDate + ".txt";

                //} while (true);
                //foreach (var order in orders)
            }

            


        
    }
}
