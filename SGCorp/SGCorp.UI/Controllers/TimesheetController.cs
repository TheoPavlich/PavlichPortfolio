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
        public ActionResult Submit()
        {
            var model = new EmployeeTimesheetVM();

            var tOps = new TimesheetOperations();
            model.ListEmployees(tOps.GetAllEmployees());
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Submit(int empId)
        {
            var model = new EmployeeTimesheetVM();
            var tOps = new TimesheetOperations();
            model.TimesheetList = tOps.GetTimesheetsByEmployeeId(empId);

            model.Employee = tOps.GetEmployeeById(empId);
            model.ListEmployees(tOps.GetAllEmployees());

            return View(model);
        }
    }
}