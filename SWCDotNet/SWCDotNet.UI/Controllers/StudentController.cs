using System.Web.Mvc;
using SWCDotNet.BLL;
using SWCDotNet.Models;

namespace SWCDotNet.UI.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult ListApprentices()
        {
            var ops = new StudentOperations();
            var results = ops.GetStudents();

            return View(results);
        }

        public ActionResult Edit(int id)
        {
            var studentOps = new StudentOperations();

            var student = studentOps.GetStudentById(id);

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            var ops = new StudentOperations();
            ops.UpdateStudent(student);

            var students = ops.GetStudents();

            return View("ListApprentices", students);
        }

        public ActionResult Remove(int id)
        {
            var ops = new StudentOperations();
            ops.RemoveStudentFromCohort(id);

            var students = ops.GetStudents();

            return View("ListApprentices", students);
        }

        public ActionResult Add()
        {
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Add(Student student)
        {
            var ops = new StudentOperations();
            ops.AddStudentToCohort(student);

            var students = ops.GetStudents();

            return View("ListApprentices", students);
        }
    }
}