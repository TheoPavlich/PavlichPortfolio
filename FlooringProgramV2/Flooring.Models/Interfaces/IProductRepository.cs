using System.Collections.Generic;

namespace Flooring.Models.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllItems();
    }
}