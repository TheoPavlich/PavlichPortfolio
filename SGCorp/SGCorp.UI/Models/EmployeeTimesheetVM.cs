using System.Collections.Generic;
using SGCorp.Models;

namespace SGCorp.UI.Models
{
    public class EmployeeTimesheetVM
    {
        public Employee Employee { get; set; }
        public List<Timesheet> TimesheetList { get; set; }
    }
}