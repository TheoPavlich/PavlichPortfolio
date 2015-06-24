using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models
{
    public class OrderRequest
    {
        public DateTime OrderDate { get; set; }
        public Order Order { get; set; }
    }
}
