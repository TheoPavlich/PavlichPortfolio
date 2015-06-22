using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data;
using Flooring.Models;

namespace FlooringBLL
{
    public class OrderOperations
    {
        public Response<Order> GetOrder(string orderNumber)
        {
            var repo = new OrderRepository();
            var response = new Response<Order>();

            try
            {
                var order = repo.GetOrder(orderNumber);

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
       
    }
}
