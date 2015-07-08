using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorp.Models;


namespace SGCorp.UI.Controllers
{
    public class ResumeController : Controller
    {
        // GET: Resume
        public ActionResult AddResume()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddResume(HttpPostedFileBase file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var path = "~/Data/Resumes/";
            path += fileName;
            var mapPath = Server.MapPath(path);
            file.SaveAs(mapPath);


            var r = new Resume();
            r.ApplicantName = Request.Form["ApplicantName"];
            r.ResumeFilePath = mapPath;

            var database = new ResumeDatabase();

            database.Add(r);

            return /*System.Web.UI.WebControls.*/ View("ResumeCompleted", r);
        }

        public ActionResult ShowFile(string filePath)
        {
            string content = "";

            try
            {
                using (var stream = new StreamReader(filePath))
                {
                    content = stream.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return Content("No file found");
            }

            return Content(content);
        }

        public ActionResult ListResumes()
        {
            var fileApplicants = new ResumeDatabase();
            //DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/Resumes/"));

            var applicants = fileApplicants.GetAll();
            //var files = directory.GetFiles().ToList();

            //foreach (var a in applicants)
            //{

            //}

            return /*System.Web.UI.WebControls.*/View(applicants);
        }
    }
}