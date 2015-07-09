using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public ActionResult DeleteSuggestion(int id)
        {
            var s = new SuggestionDatabase();
            var path = "~/DataFiles/Suggestions.txt";
            var mapPath = Server.MapPath(path);
            var suggestions = s.GetAll(mapPath);

            Suggestion suggestion = suggestions.First(sug => sug.SuggestionId == id);

            suggestions.Remove(suggestion);
            s.Delete(suggestions, mapPath);
            
            return View("DeleteSuggestion");
        }
    }
}