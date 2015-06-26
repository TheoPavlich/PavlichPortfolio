using System;
using System.Configuration;
using Flooring.Data;

namespace FlooringBLL
{
    public class OperationsMode
    {
        private static readonly string Mode = ConfigurationManager.AppSettings["Mode"];

        public static TaxOperations CreateTaxOperations()
        {
            if (Mode == "Test")
                return new TaxOperations(new StateTaxRepository());
            //return new TaxOperations(new StateTaxRepository());
            throw new Exception("Prod repository not yet implemented");
        }

        public static OrderOperations CreateOrderOperations()
        {
            if (Mode == "Test")
                return new OrderOperations(new OrderRepository(), new ProductRepository());
            //return new TaxOperations(new OrderRepository());
            throw new Exception("Prod repository not yet implemented");
        }
    }
}