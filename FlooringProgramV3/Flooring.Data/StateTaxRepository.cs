using System.Collections.Generic;
using System.IO;
using System.Linq;
using Flooring.Models;
using Flooring.Models.Interfaces;

namespace Flooring.Data
{
    public class StateTaxRepository : IStateTaxRepository
    {
        public List<StateTax> GetAllItems()
        {
            var FilePath = @"DataFiles/Taxes.txt";

            var reader = File.ReadAllLines(FilePath);

            return reader.Select(t => t.Split(',')).Select(columns => new StateTax
            {
                StateAbbreviation = columns[0],
                TaxRate = decimal.Parse(columns[1])
            }).ToList();
        }
    }
}