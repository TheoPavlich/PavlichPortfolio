using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SGCorp.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public int LocationId { get; set; }
        public int ManagerId { get; set; }
        public string Status { get; set; }
    }
}
