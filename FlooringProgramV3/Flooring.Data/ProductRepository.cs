using System.Collections.Generic;
using System.IO;
using Flooring.Models;
using Flooring.Models.Interfaces;

namespace Flooring.Data
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAllItems()
        {
            var FilePath = @"DataFiles/Products.txt";
            var products = new List<Product>();

            var reader = File.ReadAllLines(FilePath);

            for (var i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var product = new Product
                {
                    ProductType = columns[0],
                    CostPerSqFt = decimal.Parse(columns[1]),
                    LaborCostPerSqFt = decimal.Parse(columns[2])
                };


                products.Add(product);
            }
            return products;
        }
    }
}