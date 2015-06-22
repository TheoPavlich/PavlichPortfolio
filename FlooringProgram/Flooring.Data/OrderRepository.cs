using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;


namespace Flooring.Data
{
    public class OrderRepository
    {
        //private const string FilePath = @"DataFiles\_____.txt";

        public Order GetOrder(string orderNumber)
        {
            List<Order> allOrders = GetAllOrders();

            foreach (var order in allOrders)
            {
                if (order.OrderNumber == orderNumber)
                    return order;
            }

            return null;
        }

        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            //var reader = File.ReadAllLines(FilePath);

            //for (int i = 1; i < reader.Length; i++)
            //{
            //    var columns = reader[i].Split(',');

            //    var order = new Order();



            //    orders.Add(order);
            //}

            return orders;
        }

        public void WriteNewOrder(List<Order> orders)
        {
            OverwriteFile(orders);
        }

        public void DeleteOrder(List<Order> orders)
        {
            OverwriteFile(orders);
        }

        public void UpdateOrder(Order orderToUpdate)
        {
            var allOrders = GetAllOrders();

            var existingOrder = allOrders.First(a => a.OrderNumber == orderToUpdate.OrderNumber);

            
            existingOrder.FirstName = orderToUpdate.FirstName;
            existingOrder.LastName = orderToUpdate.LastName;
            existingOrder.State = orderToUpdate.State;
            existingOrder.TaxRate = orderToUpdate.TaxRate;
            existingOrder.ProductType = orderToUpdate.ProductType;
            existingOrder.Area = orderToUpdate.Area;
            existingOrder.CostPerSqFt = orderToUpdate.CostPerSqFt;
            existingOrder.LaborPerSqFt = orderToUpdate.LaborPerSqFt;
            existingOrder.MaterialCost = orderToUpdate.MaterialCost;
            existingOrder.LaborCost = orderToUpdate.LaborCost;
            existingOrder.Tax = orderToUpdate.Tax;
            existingOrder.Total = orderToUpdate.Total;

            OverwriteFile(allOrders);

        }

      private void OverwriteFile(List<Order> allOrders)
        {
            File.Delete(FilePath);

            using (var writer = File.CreateText(FilePath))
            {
                writer.WriteLine("OrderNumber,FirstName,LastName,Total");

                foreach (var order in allOrders)
                {
                    writer.WriteLine("{0},{1},{2},{3}", order.OrderNumber, order.FirstName, order.LastName, order.Total);
                }
        }
    }
}
