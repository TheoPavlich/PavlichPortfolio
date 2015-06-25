using System;
using System.Linq;
using Flooring.Data;
using Flooring.Models;
using Flooring.Models.Interfaces;
using FlooringBLL;
using FlooringUI.Utilities;

namespace FlooringUI.Workflows
{
    internal class AddOrder
    {
        public void Execute()
        {
            var request = new OrderRequest();

            CreateRequest(request);

            if (ConfirmRequest(request) == "Y")
            {
                SubmitRequest(request);
            }
            else
            {
                Console.WriteLine("Your order has not been saved.");
            }

            UserInteractions.PromptToContinue();
        }

        private void ProcessRequestInputProduct(OrderRequest request)
        {
            IProductRepository productRepository = new ProductRepositoryMock();
            var product = productRepository.GetAllItems();

            foreach (var p in product.Where(p => p.ProductType == request.Order.ProductType))
            {
                request.Order.CostPerSqFt = p.CostPerSqFt;
                request.Order.LaborPerSqFt = p.LaborCostPerSqFt;
            }
        }

        private void ProcessRequestInputTaxes(OrderRequest request)
        {
            IStateTaxRepository stateTaxRepository = new StateTaxRepositoryMock();
            var states = stateTaxRepository.GetAllItems();

            foreach (var s in states.Where(s => s.StateAbbreviation == request.Order.State))
            {
                request.Order.TaxRate = s.TaxRate;
                break;
            }
        }

        private void CreateRequest(OrderRequest request)
        {
            request.OrderDate = DateTime.Today;
            request.Order = new Order
            {
                FirstName = UserInteractions.PromptForRequiredString("Enter First Name: ", "Add"),
                LastName = UserInteractions.PromptForRequiredString("Enter Last Name: ", "Add"),
                State = UserInteractions.PromptForValidState("Enter state abbreviation: ").ToUpper(),
                Area = UserInteractions.PromptForDecimal("Enter area in square feet: ", "Add"),
                ProductType = UserInteractions.PromptForValidProduct("Enter a product type: ", "Add")
            };

            ProcessRequestInputProduct(request);
            ProcessRequestInputTaxes(request);

            request.Order.MaterialCost = request.Order.CostPerSqFt*request.Order.Area;
            request.Order.LaborCost = request.Order.LaborPerSqFt*request.Order.Area;

            var subtotal = request.Order.LaborCost + request.Order.MaterialCost;

            request.Order.Tax = subtotal*request.Order.TaxRate;
            request.Order.Total = subtotal + request.Order.Tax;
        }

        private string ConfirmRequest(OrderRequest request)
        {
            //var ops = OperationsMode.CreateOrderOperations();
            //var order - ops.PrepareOrderTotal(request);

            Console.WriteLine("Order to be committed is as follows:");
            Console.WriteLine("Name on order: {0} {1}.", request.Order.FirstName, request.Order.LastName);
            Console.WriteLine("Order Total: {0:C}", request.Order.Total);


            return UserInteractions.PromptForConfirmation("Do you want to commit this order? (Y or N): ");
        }

        private void SubmitRequest(OrderRequest request)
        {
            var ops = OperationsMode.CreateOrderOperations();
            var result = ops.AddOrder(request);

            if (result.Success)
            {
                Console.WriteLine("New order number {0} of total {1:C} has been committed.", request.Order.OrderNumber,
                    request.Order.Total);
            }
            else
            {
                Console.WriteLine("Order has not been committed.");
            }
        }
    }
}