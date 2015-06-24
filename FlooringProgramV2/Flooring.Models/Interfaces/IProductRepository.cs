using System;
using System.Collections.Generic;

namespace Flooring.Models.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllItems();
        //void Add(OrderRequest orderToAdOrderRequest); 
    }
}