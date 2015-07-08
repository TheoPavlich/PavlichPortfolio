using System.Web.Mvc;

namespace SGCorp.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //    var database = new ApplicantDatabase();

            //    var applicants = database.GetAll();

            return View();
        }
    }
}