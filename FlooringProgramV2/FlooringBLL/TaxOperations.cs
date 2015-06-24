using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models;
using Flooring.Models.Interfaces;

namespace FlooringBLL
{
    public class TaxOperations
    {
        private IStateTaxRepository _taxRepository;

        public TaxOperations(IStateTaxRepository taxRepo)
        {
            _taxRepository = taxRepo;
        }

        public List<StateTax> ListAll()
        {
            return _taxRepository.ListAll();
        }

        public decimal GetTaxRate(string stateAbbr)
        {
            var allStates = _taxRepository.ListAll();
            var state = allStates.First(s => s.StateAbbreviation == stateAbbr);

            return state.TaxRate;
        }

        public bool IsValidState(string stateAbbr)
        {
            var allStates = _taxRepository.ListAll();
            return allStates.Any(s => s.StateAbbreviation == stateAbbr);
        }
    }
}
