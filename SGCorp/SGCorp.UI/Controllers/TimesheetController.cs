using System.Web.Mvc;
using SGCorp.BLL;
using SGCorp.Data;
using SGCorp.Models;
using SGCorp.UI.Models;

namespace SGCorp.UI.Controllers
{
    public class TimesheetController : Controller
    {
        // GET: Timesheet
        public ActionResult Timesheet()
        {
            var model = new EmployeeTimesheetVM();
            var tOps = new TimesheetOperations();
            model.ListEmployees(tOps.GetAllEmployees());
            
            
            return View(model);
        }

        public ActionResult UserChoice(int empId, string option)
        {
            var action = "";
            if (option == "Submit a Timesheet")
            {
                action = "Submit";
            }
            else
            {
                action = "ViewHours";
            }
            return RedirectToAction(action, new{empId=empId});
        }
  
        [HttpPost]
        public ActionResult Submit(int empId, Timesheet timesheet)
        {
            var model = new EmployeeTimesheetVM();
            var tOps = new TimesheetOperations();
            timesheet.EmpId = empId;
            model.Employee = tOps.GetEmployeeById(empId);
            model.ListEmployees(tOps.GetAllEmployees());

            tOps.AddTimesheet(timesheet);
            return View(model);
        }

        //public ActionResult ViewHours()
        //{
        //    var model = new EmployeeTimesheetVM();

        //    var tOps = new TimesheetOperations();
        //    model.ListEmployees(tOps.GetAllEmployees());

        //    return View(model);
        //}

        //[HttpPost]
        public ActionResult ViewHours(int empId)
        {
            var model = new EmployeeTimesheetVM();
            var tOps = new TimesheetOperations();
            model.TimesheetList = tOps.GetTimesheetsByEmployeeId(empId);
            model.Employee = tOps.GetEmployeeById(empId);
            model.ListEmployees(tOps.GetAllEmployees());

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteTimesheet(int timeId, int empId)
        {
            var model = new EmployeeTimesheetVM();
            var tOps = new TimesheetOperations();
            tOps.DeleteTimesheet(timeId);
             
            model.TimesheetList = tOps.GetTimesheetsByEmployeeId(empId);
            model.Employee = tOps.GetEmployeeById(empId);
            model.ListEmployees(tOps.GetAllEmployees());

            return View("ViewHours", model);
        }
    }
}