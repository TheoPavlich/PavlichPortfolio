﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorp.Data;
using SGCorp.Models;

namespace SGCorp.BLL
{
    public class TimesheetOperations
    {
        public List<Employee> GetAllEmployees()
        {
            var repo = new TimesheetRepository();
            return repo.GetAllEmployees();
        }

        public Employee GetEmployeeById(int id)
        {
            var repo = new TimesheetRepository();
            return repo.GetEmployeeById(id);
        }

        public List<Timesheet> GetAllTimesheets()
        {
            var repo = new TimesheetRepository();
            return repo.GetAllTimesheets();
        }

        public void DeleteTimesheet(int id)
        {
            var repo = new TimesheetRepository();
            repo.DeleteTimesheet(id);
        }

        public void AddTimesheet(Timesheet timesheet)
        {
            var repo = new TimesheetRepository();
            repo.AddTimesheet(timesheet);
        }
    }
}