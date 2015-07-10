using System.ComponentModel.DataAnnotations;

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