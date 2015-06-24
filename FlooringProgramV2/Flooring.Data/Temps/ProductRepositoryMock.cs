using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;

namespace Flooring.Data.Temps
{
    class ProductRepositoryMock
    {
        public List<Product> GetAllItems()
        {
            var FilePath = @"DataFiles/Products.txt";
            List<Product> products = new List<Product>();

            var reader = File.ReadAllLines(FilePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

               var product = new Product();

                product.ProductType = columns[0];
                product.CostPerSqFt = decimal.Parse(columns[1]);
                product.LaborCostPerSqFt = decimal.Parse(columns[2]);
            }


            return products;
          
            /*return new List<StateTax>()
            {
                new StateTax() {StateAbbreviation = "OH", TaxRate = 0.065M},
                new StateTax() {StateAbbreviation = "PA", TaxRate = 0.075M}
            };*/
        }
    }
    
}
