using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data;
using Flooring.Models;
using Flooring.Models.Interfaces;

namespace FlooringBLL
{
    public class OrderOperations
    {
        private IOrderRepository _orderRepo;

        public OrderOperations(IOrderRepository myRepo)
        {
            _orderRepo = myRepo;
        }

        public Response<Order> GetOrder(string orderNumber, string date)
        {
            var repo = new OrderRepository();
            var response = new Response<Order>();

            try
            {
                var order = repo.GetOrder(orderNumber,date);

                if (order == null)
                {
                    response.Success = false;
                    response.Message = "Order Not Found!";
                }
                else
                {
                    response.Success = true;
                    response.Data = order;
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;

        }

        public Response<Order> AddOrder(OrderRequest request)
        {
            var response = new Response<Order>();

            try
            {
                var orders = _orderRepo.GetAllItems("Order_"+request.OrderDate.ToString("MMddyyy"));

                int orderNumber = 0;

                if (orders != null)
                    orderNumber = orders.Max(o => Int32.Parse(o.OrderNumber));

                orderNumber++;

                request.Order.OrderNumber = orderNumber.ToString();

                _orderRepo.Add(request);

                response.Success = true;
                response.Data = request.Order;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public decimal GetCostPerSqFt(string productType)
        {
            var products = @"DataFiles/Products.txt";
            var reader = File.ReadAllLines(products);

            for (int i = 1; i < reader.Length; i++)
            {
                var column = reader[i].Split(',');
                if (column[0] == productType)
                {
                    return decimal.Parse(column[1]);
                }
            }
            return 0;
        }

        public decimal GetLaborPerSqFt(string productType)
        {
            var products = @"DataFiles/Products.txt";
            var reader = File.ReadAllLines(products);

            for (int i = 1; i < reader.Length; i++)
            {
                var column = reader[i].Split(',');
                if (column[0] == productType)
                {
                    return decimal.Parse(column[2]);
                }
            }
            return 0;
        }
    }
}
