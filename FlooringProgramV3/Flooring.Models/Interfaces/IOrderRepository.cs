using System.Collections.Generic;

namespace Flooring.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAllItems(string orderDate);
        void Add(OrderRequest orderToAdd);
    }
}