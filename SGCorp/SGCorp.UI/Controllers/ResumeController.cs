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
        public ActionResult AddResume(HttpPostedFileBase file, Resume resume)
        {
            var fileName = Path.GetFileName(file.FileName);
            var path = "~/Resumes/";
            path += fileName;
            var mapPath = Server.MapPath(path);
            file.SaveAs(mapPath);

            var r = new ResumeDatabase();
            var textPath = "~/DataFiles/Resume.txt";
            var textMapPath = Server.MapPath(textPath);

            r.Add(resume, textMapPath);

            if (ModelState.IsValid)
            {
                return View("ResumeCompleted", resume);
            }
            return View(resume);
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
            var fileResumes = new ResumeDatabase();
            
            var path = "~/DataFiles/Resumes.txt";
            var mapPath = Server.MapPath(path);

            var resumes = fileResumes.GetAll(mapPath);

            return View(resumes);
        }
    }
}