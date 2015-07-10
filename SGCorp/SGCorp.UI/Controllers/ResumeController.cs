using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using SGCorp.BLL;
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
            resume.ResumeFilePath = mapPath;

            var r = new ResumeOperations();
            var textPath = "~/DataFiles/Resume.txt";
            var textMapPath = Server.MapPath(textPath);

            r.AddResume(resume, textMapPath);

            if (ModelState.IsValid)
            {
                return View("ResumeCompleted", resume);
            }
            return View(resume);
        }

        public ActionResult ShowFile(string filePath)
        {
            var content = "";

            try
            {
                using (var stream = new StreamReader(filePath))
                {
                    content = stream.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                content = ex.Message;
            }
            return Content(content);
        }

        public ActionResult ListResumes()
        {
            var r = new ResumeOperations();

            var path = "~/DataFiles/Resumes.txt";
            var mapPath = Server.MapPath(path);

            var resumes = r.GetAll(mapPath);

            return View(resumes);
        }
    }
}