using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.WebPages.Html;
using SGCorp.Models;

namespace SGCorp.UI.Models
{
    public class EmployeeTimesheetVM
    {
        public Employee Employee { get; set; }
        public List<Timesheet> TimesheetList { get; set; }
        public List<SelectListItem> Employees { get; set; } 

        public void ListEmployees(List<Employee> employees)
        {
            Employees = new List<SelectListItem>();

            foreach (var e in employees)
            {
                Employees.Add(new SelectListItem() {Text=e.LastName + ", " + e.FirstName, Value = e.EmpId.ToString()});
            }
        }
    }
}