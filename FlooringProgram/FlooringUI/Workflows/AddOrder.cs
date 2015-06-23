using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
            //GetAllOrders fetches only orders for specific DATE
            string date = DateTime.Today.ToString("MMddyyy");
            List<Order> orders = repo.GetAllOrders(date);

            string orderNumber = "";

            if (orders != null)
            {
                orderNumber = GetNewOrderNumber(orders);
            }
            else
            {
                orderNumber = "1";
            }

            Order newOrder = GetOrderInformation(orderNumber);
            bool commit = DisplayNewOrderSummary(newOrder);
            
            if (commit)
            {
                orders.Add(newOrder);
                repo.WriteNewOrder(orders,date);
                Console.WriteLine("New oreder has been committed. Press enter to continue...");
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

            Console.WriteLine("\nEnter customer state: ");
            string state = Console.ReadLine();

            Console.WriteLine("\nEnter Product Type: ");
            string productType = Console.ReadLine();

            bool valid;
            decimal area;
            do
            {
                valid = true;
                Console.WriteLine("\nEnter job area: ");
                valid = Decimal.TryParse(Console.ReadLine(), out area);
            } while (!valid);

            
            var order = new Order();
            order.FirstName = firstName;
            order.LastName = lastName;
            order.OrderNumber = orderNumber;
            order.State = state;
            order.ProductType = productType;
            order.Area = area;

            //here will be calculations base on data files for other Order info
            //here be demons

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

        }
    }
}
