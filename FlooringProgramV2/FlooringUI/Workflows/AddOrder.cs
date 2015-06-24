using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data;
using Flooring.Models;
using FlooringBLL;
using FlooringUI.Utilities;

namespace FlooringUI.Workflows
{
    class AddOrder
    {
        public void Execute()
        {
            var request = new OrderRequest();
            
            CreateRequest(request);

            if (ConfirmRequest(request) =="Y")
            {
                SubmitRequest(request);
            }
            else
            {
                Console.WriteLine("Your order has not been saved.");
            }

            UserInteractions.PromptToContinue();
        }

        private void CreateRequest(OrderRequest request)
        {
            request.OrderDate = DateTime.Today;
            request.Order = new Order();
            request.Order.FirstName = UserInteractions.PromptForRequiredString("Enter First Name: ");
            request.Order.LastName = UserInteractions.PromptForRequiredString("Enter Last Name: ");
            request.Order.State = UserInteractions.PromptForValidState("Enter state abbreviation: ");
            request.Order.Area = UserInteractions.PromptForDecimal("Enter area in square feet: ");
            request.Order.ProductType = UserInteractions.PromptForRequiredString("Enter a product type: ");
        }

        private string ConfirmRequest(OrderRequest request)
        {
            var ops = OperationsMode.CreateOrderOperations();
            //var order - ops.PrepareOrderTotal(request);

            Console.WriteLine("Order to be committed is as follows:");
            Console.WriteLine("Name on order: {0} {1}.", request.Order.FirstName, request.Order.LastName);
            Console.WriteLine("Order Total: {0:C}", request.Order.Total);


            return UserInteractions.PromptForConfirmation("Do you want to commit this order? (Y or N): ");
        }

        private void SubmitRequest(OrderRequest request)
        {
            var ops = OperationsMode.CreateOrderOperations();
            var result = ops.AddOrder(request);

            if (result.Success)
            {
                Console.WriteLine("New order number {0} of total {1:C} has been committed.", request.Order.OrderNumber, request.Order.Total);
            }
            else
            {
                Console.WriteLine("Order has not been committed.");
            }
        }

        /*private string GetNewOrderNumber(List<Order> orders)
        {
            var orderNumbers = from o in orders
                select o.OrderNumber;
            var maxOrder = orderNumbers.Max();

            int maxInt;
            Int32.TryParse(maxOrder, out maxInt);
            string maxString = (maxInt + 1).ToString();
            return maxString;
        }

        private Order GetOrderInformation(string orderNumber)
        {
            var repo = new OrderRepository();

            Console.WriteLine("\nEnter customer first name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("\nEnter customer last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("\nEnter customer state abbreviation: ");
            string state = Console.ReadLine().ToUpper();

            Console.WriteLine("\nEnter Product Type: ");
            string productType = Console.ReadLine().ToUpper();


            bool valid;
            decimal area;
            do
            {
                valid = true;
                Console.WriteLine("\nEnter flooring area in square feet: ");
                valid = Decimal.TryParse(Console.ReadLine(), out area);
            } while (!valid);

             
            
            var order = new Order();
            order.FirstName = firstName;
            order.LastName = lastName;
            order.OrderNumber = orderNumber;
            order.State = state;
            order.ProductType = productType;
            order.Area = area;
            order.TaxRate=repo.GetTaxRate(state);
            order.CostPerSqFt = repo.GetCostPerSqFt(productType);
            order.LaborPerSqFt = repo.GetLaborPerSqFt(productType);
            order.MaterialCost = order.CostPerSqFt*order.Area;
            order.LaborCost = order.LaborPerSqFt*order.Area;

            decimal subtotal = order.MaterialCost + order.LaborCost;

            order.Tax = subtotal*order.TaxRate;
            order.Total = subtotal + order.Tax;

            return order;
        }

        private bool DisplayNewOrderSummary(Order order)
        {
            Console.WriteLine("Order to be committed is as follows:");
            Console.WriteLine("Name on order: {0} {1}.", order.FirstName, order.LastName);
            Console.WriteLine("Order number: {0}\n Order Total: {1:C}", order.OrderNumber, order.Total);
            Console.WriteLine("Is this correct? (Y or N)");
            string yesOrNo = Console.ReadLine().ToUpper();
            if (yesOrNo == "Y")
            {
                return true;
            }
            return false;

        }*/
    }
}
