using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using SGCorp.UI.Models;

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

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddResume(HttpPostedFileBase file)
        {
            var fileName = Path.GetFileName(file.FileName);
            var path = "~/Resumes/";
            path += fileName;
            var mapPath = Server.MapPath(path);
            file.SaveAs(mapPath);


            var a = new Applicant();
            a.ApplicantName = Request.Form["ApplicantName"];
            a.ApplicantResumeFilePath = mapPath;

            var database = new ApplicantDatabase();

            database.Add(a);

            return View("ResumeCompleted", a);
        }

        public ActionResult ShowFile(string filePath)
        {
            string content = string.Empty;

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
            var fileApplicants = new ApplicantDatabase();
            //DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/Resumes/"));

            var applicants = fileApplicants.GetAll();
            //var files = directory.GetFiles().ToList();

            //foreach (var a in applicants)
            //{
                
            //}

            return View(applicants);
        }

        public ActionResult AddSuggestion()
        {
            return View(new Suggestion());
        }

        [HttpPost]
        public ActionResult AddSuggestion(Suggestion suggestion)
        {
            var s = new SuggestionDatabase();
            var path = "~/DataFiles/Suggestions.txt";
            var mapPath = Server.MapPath(path);
            
            s.Add(suggestion, mapPath);

            //s.EmployeeName = Request.Form["Employee Name"];
            //s.SuggestionId = int.Parse(Request.Form["Suggestion ID"]);
            //s.SuggestionText = Request.Form["Suggestion Text"];
            if (ModelState.IsValid)
            {
                return View("SuggestionCompleted", suggestion);
            }
            return View(suggestion);
        }

        public ActionResult ViewSuggestions()
        {
            var s = new SuggestionDatabase();
            var path = "~/DataFiles/Suggestions.txt";
            var mapPath = Server.MapPath(path);

            var suggestions = s.GetAll(mapPath);

            return View(suggestions);
        }

       
    }
}