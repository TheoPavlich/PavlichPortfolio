using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data;
using Flooring.Models;

namespace FlooringUI.Workflows
{
    class AddOrder
    {
        public void Execute()
        {
            var repo = new OrderRepository();
            List<Order> orders = repo.GetAllOrders();

            string orderNumber = GetNewOrderNumber(orders);
            Order newOrder = GetOrderInformation(orderNumber);
            orders.Add(newOrder);
            bool commit = DisplayNewOrderSummary(newOrder);
            if (commit)
            {
                repo.WriteNewOrder(orders);
            }
            else
            {
                Console.WriteLine("Order has not been committed. Press enter to return to main menu.");
            }
            Console.ReadLine();
        }

        private string GetNewOrderNumber(List<Order> orders)
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
            Console.WriteLine("\nEnter customer first name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("\nEnter customer last name: ");
            string lastName = Console.ReadLine();

            //And all those other things

            var order = new Order();
            order.FirstName = firstName;
            order.LastName = lastName;
            order.OrderNumber = orderNumber;

            return order;
        }

        private bool DisplayNewOrderSummary(Order order)
        {
            Console.WriteLine("Order to be committed is as follows:");
            Console.WriteLine("Name on order: {0} {1}.", order.FirstName, order.LastName);
            Console.WriteLine("Order number: {0}\n Order Total: {1:C}", order.OrderNumber, order.Total);

        
        }
    }
}
