using System;
using System.Linq;
using Flooring.Models;
using Flooring.Models.Interfaces;

namespace FlooringBLL
{
    public class OrderOperations
    {
        private readonly IOrderRepository _orderRepo;

        private readonly IProductRepository _productRepository;

        public OrderOperations(IOrderRepository myRepo, IProductRepository productRepository)
        {
            _orderRepo = myRepo;
            _productRepository = productRepository;
        }

        /* public Response<Order> GetOrder(string orderNumber, string date)
        {
            var repo = new OrderRepository();
            var response = new Response<Order>();

            try
            {
                var order = repo.GetOrder(orderNumber, date);

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

        }*/

        public Response<Order> AddOrder(OrderRequest request)
        {
            var response = new Response<Order>();

            try
            {
                var orders = _orderRepo.GetAllItems("Orders_" + request.OrderDate.ToString("MMddyyy"));

                var orderNumber = 0;

                if (orders != null)
                    orderNumber = orders.Max(o => int.Parse(o.OrderNumber));

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

        public bool IsValidProduct(string product)
        {
            var allProducts = _productRepository.GetAllItems();
            return allProducts.Any(p => p.ProductType == product);
        }
    }
}