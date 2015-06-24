using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;
using Flooring.Models.Interfaces;

namespace Flooring.Data.Temps
{
    public class StateTaxRepositoryMock : IStateTaxRepository
    {
        public List<StateTax> ListAll()
        {
            return new List<StateTax>()
            {
                new StateTax() {StateAbbreviation = "OH", TaxRate = 0.065M},
                new StateTax() {StateAbbreviation = "PA", TaxRate = 0.075M}
            };
        }
    }
}
