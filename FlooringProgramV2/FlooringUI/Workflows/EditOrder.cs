using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data;
using Flooring.Data.Temps;
using Flooring.Models;
using Flooring.Models.Interfaces;
using FlooringBLL;
using FlooringUI.Utilities;

namespace FlooringUI.Workflows
{
    internal class EditOrder
    {
        public void Execute()
        {
            string orderFile = GetOrderDateFromUser();
            List<Order> orders = FindOrderFile(orderFile);
            if (orders.Count!=0)
            {
                int userChoice =
                    UserInteractions.PromptForChoice("Select order number to edit. Press 0 to return to main menu.\n", 0,
                        orders.Count);
                if (userChoice != 0)
                {
                    Order updatedOrder = EditSelectedOrder(userChoice.ToString(), orders);
                    string confirm =
                        UserInteractions.PromptForConfirmation("Would you like to commit these order edits?");
                    if (confirm == "Y")
                    {
                        // orders.Add(updatedOrder)

                        var ops = new OrderRepository();
                        ops.UpdateOrder(updatedOrder, orderFile.Substring(17, 8));
                        Console.WriteLine("Order has been committed.");
                        UserInteractions.PromptToContinue();
                    }
                }
            }
        }

        private Order EditSelectedOrder(string orderNumber, List<Order> orders)
        {
            Console.Clear();
            var order = orders.First(o => o.OrderNumber == orderNumber);
            Order updatedOrder = new Order();
            updatedOrder.OrderNumber = orderNumber;
            updatedOrder.FirstName = UserInteractions.PromptForRequiredString(("First Name ("+ order.FirstName+"): "), "Edit");
            updatedOrder.LastName = UserInteractions.PromptForRequiredString(("Last Name (" + order.LastName + "): "), "Edit");
            updatedOrder.State = UserInteractions.PromptForValidStateEdit("State Abbreviation (" + order.State + "): ");
            updatedOrder.Area = UserInteractions.PromptForDecimal(("Area (" + order.Area + "): "), "Edit");
            updatedOrder.ProductType = UserInteractions.PromptForRequiredString(("Product Type (" + order.ProductType + "): "), "Edit");
            
            if (updatedOrder.ProductType != order.ProductType)
            {
                ProcessRequestInputProduct(updatedOrder);
            }
            else
            {
                updatedOrder.CostPerSqFt = order.CostPerSqFt;
                updatedOrder.LaborPerSqFt = order.LaborPerSqFt;
            }
            
            updatedOrder.CostPerSqFt = UserInteractions.PromptForDecimal(("Material Cost Per Square Foot (" + updatedOrder.CostPerSqFt + "): "), "Edit");
            updatedOrder.LaborPerSqFt = UserInteractions.PromptForDecimal(("Labor Cost Per Square Foot (" + updatedOrder.LaborPerSqFt + "): "), "Edit");

            if (updatedOrder.State != order.State)
            {
                ProcessRequestInputTaxes(updatedOrder);
            }
            else
            {
                updatedOrder.TaxRate = order.TaxRate;
            }

            updatedOrder.MaterialCost = updatedOrder.CostPerSqFt * updatedOrder.Area;
            updatedOrder.LaborCost = updatedOrder.LaborPerSqFt * updatedOrder.Area;

            var subtotal = updatedOrder.LaborCost + updatedOrder.MaterialCost;

            updatedOrder.Tax = subtotal * updatedOrder.TaxRate;
            updatedOrder.Total = subtotal + updatedOrder.Tax;

            return updatedOrder;
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
        
        public string GetOrderDateFromUser()
        {

            Console.Clear();

            Console.Write("Enter an order date (MMddyyyy): ");
            string orderDate = Console.ReadLine();

            return @"DataFiles\Orders_" + orderDate + ".txt";
        }

        private void ProcessRequestInputProduct(Order updatedOrder)
        {
            IProductRepository productRepository = new ProductRepositoryMock();
            var product = productRepository.GetAllItems();

            foreach (var p in product.Where(p => p.ProductType == updatedOrder.ProductType))
            {
                updatedOrder.CostPerSqFt = p.CostPerSqFt;
                updatedOrder.LaborPerSqFt = p.LaborCostPerSqFt;
            }

        }

        private void ProcessRequestInputTaxes(Order updatedOrder)
        {

            IStateTaxRepository stateTaxRepository = new StateTaxRepositoryMock();
            var states = stateTaxRepository.GetAllItems();

            foreach (var s in states.Where(s => s.StateAbbreviation == updatedOrder.State))
            {
                updatedOrder.TaxRate = s.TaxRate;
                break;
            }

        }

    }
}
