using System.Collections.Generic;
using System.Linq;
using Flooring.Models;
using Flooring.Models.Interfaces;

namespace FlooringBLL
{
    public class TaxOperations
    {
        private readonly IStateTaxRepository _taxRepository;

        public TaxOperations(IStateTaxRepository taxRepo)
        {
            _taxRepository = taxRepo;
        }

        public List<StateTax> GetAllItems()
        {
            return _taxRepository.GetAllItems();
        }

        public decimal GetTaxRate(string stateAbbr)
        {
            var allStates = _taxRepository.GetAllItems();
            var state = allStates.First(s => s.StateAbbreviation == stateAbbr);

            return state.TaxRate;
        }

        public bool IsValidState(string stateAbbr)
        {
            var allStates = _taxRepository.GetAllItems();
            return allStates.Any(s => s.StateAbbreviation == stateAbbr);
        }
    }
}