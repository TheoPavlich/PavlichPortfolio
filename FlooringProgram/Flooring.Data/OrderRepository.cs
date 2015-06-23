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
        private string FilePath;
        //FUCK EVERYTHING DAMMIT 

        public Order GetOrder(string orderNumber, string date)
        {
            List<Order> allOrders = GetAllOrders(date);

            foreach (var order in allOrders)
            {
                if (order.OrderNumber == orderNumber)
                    return order;
            }

            return null;
        }

        public List<Order> GetAllOrders(string date)
        {
            FilePath = @"DataFiles/Orders_" + date + ".txt";
            List<Order> orders = new List<Order>();

            if (File.Exists(FilePath))
            {
                var reader = File.ReadAllLines(FilePath);

                for (int i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split(',');

                    var order = new Order();

                    order.OrderNumber = columns[0];
                    order.FirstName = columns[1];
                    order.LastName = columns[2];
                    order.State = columns[3];
                    order.ProductType = columns[4];
                    order.Area = decimal.Parse(columns[5]);
                    order.CostPerSqFt = decimal.Parse(columns[6]);
                    order.LaborCost = decimal.Parse(columns[7]);
                    order.LaborPerSqFt = decimal.Parse(columns[8]);
                    order.MaterialCost = decimal.Parse(columns[9]);
                    order.TaxRate = decimal.Parse(columns[10]);
                    order.Tax = decimal.Parse(columns[11]);
                    order.Total = decimal.Parse(columns[12]);


                    orders.Add(order);
                }
            }
            return orders;
        }

        public void WriteNewOrder(List<Order> orders, string date)
        {
            OverwriteFile(orders,date);
        }

        public void DeleteOrder(List<Order> orders, string date)
        {
            OverwriteFile(orders,date);
        }

        public void UpdateOrder(Order orderToUpdate, string date)
        {
            var allOrders = GetAllOrders(date);

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

            OverwriteFile(allOrders,date);

        }

        private void OverwriteFile(List<Order> allOrders, string date)
        {
            FilePath = @"DataFiles\Orders_"+date+".txt";
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }
            else
            {
                File.Create(FilePath);
               }
            using (var writer = File.CreateText(FilePath))
            {
                writer.WriteLine("OrderNumber,FirstName,LastName,State,ProductType,Area,CostPerSqFt,LaborCost,LaborPerSqFt,MaterialCost,TaxRate,Tax,Total");

                foreach (var order in allOrders)
                {
                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", order.OrderNumber, order.FirstName, order.LastName, order.State,order.ProductType,order.Area,order.CostPerSqFt,order.LaborCost,
                        order.LaborPerSqFt,order.MaterialCost, order.TaxRate,order.Tax,order.Total);
                }
            }
        }
    }
}
