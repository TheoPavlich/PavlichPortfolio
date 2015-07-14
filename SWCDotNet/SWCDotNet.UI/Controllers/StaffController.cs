using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SWCDotNet.BLL;
using SWCDotNet.Models;

namespace SWCDotNet.UI.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult ListStaff()
        {
            var ops = new StaffOperations();
            var results = ops.GetStaff();

            return View(results);
        }

        public ActionResult Edit(int id)
        {
            var ops = new StaffOperations();

            var staff = ops.GetStaffById(id);

            return View(staff);
        }

        [HttpPost]
        public ActionResult Edit(Staff staff)
        {
            var ops = new StaffOperations();
            ops.UpdateStaff(staff);

            var staffMembers = ops.GetStaff();

            return View("ListStaff", staffMembers);
        }

        public ActionResult Remove(int id)
        {
            var ops = new StaffOperations();
            ops.RemoveStaffMember(id);

            var staff = ops.GetStaff();

            return View("ListStaff", staff);
        }

        public ActionResult Add()
        {
            return View(new Staff());
        }

        [HttpPost]
        public ActionResult Add(Staff staff)
        {
            var ops = new StaffOperations();
            ops.AddStaffMember(staff);

            var results = ops.GetStaff();

            return View("ListStaff", results);
        }
    }
}