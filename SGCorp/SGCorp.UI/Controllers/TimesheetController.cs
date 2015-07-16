using System.Web.Mvc;
using SGCorp.BLL;
using SGCorp.Data;
using SGCorp.UI.Models;

namespace SGCorp.UI.Controllers
{
    public class TimesheetController : Controller
    {
        // GET: Timesheet
        public ActionResult Index()
        {
            var model = new EmployeeTimesheetVM();

            var tOps = new TimesheetOperations();
            model.ListEmployees(tOps.GetAllEmployees());

            return View(model);
        }
    }
}