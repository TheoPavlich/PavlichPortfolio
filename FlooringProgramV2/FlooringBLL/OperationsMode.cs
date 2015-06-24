using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Data;
using Flooring.Data.Temps;
using FlooringBLL;

namespace FlooringBLL
{
    public class OperationsMode
    {
        private static string mode = ConfigurationManager.AppSettings["Mode"];

        public static TaxOperations CreateTaxOperations()
        {
            if (mode == "Test")
                return new TaxOperations(new StateTaxRepositoryMock());
            else
            {
                //return new TaxOperations(new StateTaxRepository());
                throw new Exception("Prod repository not yet implemented");
            }
        }

        public static OrderOperations CreateOrderOperations()
        {
            if (mode == "Test")
                return new OrderOperations(new OrderRepository());
            else
            {
                //return new TaxOperations(new OrderRepository());
                throw new Exception("Prod repository not yet implemented");
            }
        }
    }
}
