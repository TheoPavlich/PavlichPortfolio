using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGCorp.Models
{
    public class Suggestion
    {
        public int SuggestionId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string SuggestionText { get; set; }
    }
}