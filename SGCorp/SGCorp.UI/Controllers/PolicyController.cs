using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SGCorp.UI.Controllers
{
    public class PolicyController : Controller
    {
        // GET: Policy
        public ActionResult ViewDocuments()
        {
            return View();
        }

        public ActionResult ManageDocuments()
        {
            return View();
        }
    }
}