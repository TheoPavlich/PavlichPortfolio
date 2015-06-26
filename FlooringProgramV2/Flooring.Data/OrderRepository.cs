using System.Collections.Generic;
using System.IO;
using System.Linq;
using Flooring.Models;
using Flooring.Models.Interfaces;

namespace Flooring.Data
{
    public class OrderRepository : IOrderRepository
    {
        private string _filePath;

        public List<Order> GetAllItems(string fileName)
        {
            _filePath = @"DataFiles/" + fileName + ".txt";
            var orders = new List<Order>();

            if (File.Exists(_filePath))
            {
                var reader = File.ReadAllLines(_filePath);

                for (var i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split('~');

                    var order = new Order
                    {
                        OrderNumber = columns[0],
                        FirstName = columns[1],
                        LastName = columns[2],
                        State = columns[3],
                        ProductType = columns[4],
                        Area = decimal.Parse(columns[5]),
                        CostPerSqFt = decimal.Parse(columns[6]),
                        LaborCost = decimal.Parse(columns[7]),
                        LaborPerSqFt = decimal.Parse(columns[8]),
                        MaterialCost = decimal.Parse(columns[9]),
                        TaxRate = decimal.Parse(columns[10]),
                        Tax = decimal.Parse(columns[11]),
                        Total = decimal.Parse(columns[12])
                    };



                    orders.Add(order);
                }
                return orders;
            }
            return null;
        }

        public void Add(OrderRequest orderToAdd)
        {
            //Might also use for edit
            var orders = GetAllItems("Orders_" + orderToAdd.OrderDate.ToString("MMddyyyy")) ?? new List<Order>();

            orders.Add(orderToAdd.Order);

            OverwriteFile(orders, orderToAdd.OrderDate.ToString("MMddyyyy"));
        }

        public Order GetOrder(string orderNumber, string date)
        {
            var allOrders = GetAllItems("Order_" + date);

            return allOrders.FirstOrDefault(order => order.OrderNumber == orderNumber);
        }

        //Many of the below methods may move elsewhere.

        public void DeleteOrder(List<Order> orders, string date)
        {
            OverwriteFile(orders, date);
        }

        public void UpdateOrder(Order orderToUpdate, string date)
        {
            var allOrders = GetAllItems("Orders_" + date);

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

            OverwriteFile(allOrders, date);
        }

        private void OverwriteFile(List<Order> allOrders, string date)
        {
            _filePath = @"DataFiles\Orders_" + date + ".txt";
            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            using (var writer = File.CreateText(_filePath))
            {
                writer.WriteLine(
                    "OrderNumber~FirstName~LastName~State~ProductType~Area~CostPerSqFt~LaborCost~LaborPerSqFt~MaterialCost~TaxRate~Tax~Total");

                foreach (var order in allOrders)
                {
                    writer.WriteLine("{0}~{1}~{2}~{3}~{4}~{5}~{6}~{7}~{8}~{9}~{10}~{11}~{12}", order.OrderNumber,
                        order.FirstName, order.LastName, order.State, order.ProductType, order.Area, order.CostPerSqFt,
                        order.LaborCost,
                        order.LaborPerSqFt, order.MaterialCost, order.TaxRate, order.Tax, order.Total);
                }
            }
        }
    }
}