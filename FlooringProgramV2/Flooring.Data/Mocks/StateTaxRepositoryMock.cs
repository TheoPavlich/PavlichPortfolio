using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;
using Flooring.Models.Interfaces;

namespace Flooring.Data.Temps
{
    public class StateTaxRepositoryMock : IStateTaxRepository
    {
        public List<StateTax> GetAllItems()
        {
            var FilePath = @"DataFiles/Taxes.txt";
            List<StateTax> taxes = new List<StateTax>();

            var reader = File.ReadAllLines(FilePath);

            for (int i = 0; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var tax = new StateTax();

                tax.StateAbbreviation = columns[0];
                tax.TaxRate = decimal.Parse(columns[1]);

                taxes.Add(tax);
            }
            return taxes;
        }
    }
}
