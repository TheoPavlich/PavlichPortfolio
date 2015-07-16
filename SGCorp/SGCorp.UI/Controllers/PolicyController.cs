using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using SGCorp.BLL;
using SGCorp.Models;

namespace SGCorp.UI.Controllers
{
    public class PolicyController : Controller
    {
        // GET: Policy
        public ActionResult AddDocument()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDocument(HttpPostedFileBase file, Document doc)
        {
            var fileName = Path.GetFileName(file.FileName);
            var path = "~/Policies/";
            path += fileName;
            var mapPath = Server.MapPath(path);
            file.SaveAs(mapPath);
            doc.DocumentFilePath = mapPath;

            var r = new DocumentOperations();
            var textPath = "~/DataFiles/Documents.txt";
            var textMapPath = Server.MapPath(textPath);

            r.AddDocument(doc, textMapPath);

            if (ModelState.IsValid)
            {
                return View("DocumentCompleted", doc);
            }
            return View(doc);
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

        public ActionResult ListDocuments()
        {
            var r = new DocumentOperations();

            var path = "~/DataFiles/Documents.txt";
            var mapPath = Server.MapPath(path);

            var documents = r.GetAll(mapPath);

            return View(documents);
        }
    }
}