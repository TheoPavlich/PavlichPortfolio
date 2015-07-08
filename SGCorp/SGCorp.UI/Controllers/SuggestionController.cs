using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SGCorp.Models;


namespace SGCorp.UI.Controllers
{
    public class SuggestionController : Controller
    {
        // GET: Suggestion
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