using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SGCorp.UI.Models
{
    public class Suggestion
    {
        public int SuggestionId { get; set; }

        public string EmployeeName { get; set; }

        public string SuggestionText { get; set; }
    }
}