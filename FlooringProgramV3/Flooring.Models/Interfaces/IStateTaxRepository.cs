using System.Collections.Generic;

namespace Flooring.Models.Interfaces
{
    public interface IStateTaxRepository
    {
        List<StateTax> GetAllItems();
    }
}