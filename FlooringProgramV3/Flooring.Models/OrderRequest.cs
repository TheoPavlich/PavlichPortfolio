using System;

namespace Flooring.Models
{
    public class OrderRequest
    {
        public DateTime OrderDate { get; set; }
        public Order Order { get; set; }
    }
}