using System.Collections.Generic;
using System.IO;
using System.Linq;
using SGCorp.Models;

namespace SGCorp.Data
{
    public class SuggestionRepository
    {
        //private const string filePath = @"~/DataFiles/_suggestions.txt";
        //private static List<Suggestion>  _suggestions = new List<Suggestion>();

        public Suggestion GetSuggestion(int id, string filePath)
        {
            var suggestions = GetAllSuggestions(filePath);

            return suggestions.FirstOrDefault(s => s.SuggestionId == id);
        }

        public List<Suggestion> GetAllSuggestions(string filePath)
        {
            var suggestions = new List<Suggestion>();

            if (File.Exists(filePath))
            {
                var reader = File.ReadAllLines(filePath);

                for (var i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split('`');

                    var suggestion = new Suggestion
                    {
                        SuggestionId = int.Parse(columns[0]),
                        EmployeeName = columns[1],
                        SuggestionText = (columns[2])
                    };
                    suggestions.Add(suggestion);
                }
            }
            return suggestions;
        }

        public void Add(Suggestion suggestion, string filePath)
        {
            var suggestions = GetAllSuggestions(filePath);
            if (suggestions.Any())
                suggestion.SuggestionId = suggestions.Max(s => s.SuggestionId) + 1;
            else
                suggestion.SuggestionId = 1;

            suggestions.Add(suggestion);

            OverwriteFile(suggestions, filePath);
        }

        public void Delete(Suggestion suggestion, string filePath)
        {
            var suggestions = GetAllSuggestions(filePath);
            suggestions.Remove(suggestion);
            OverwriteFile(suggestions, filePath);
        }

        public void OverwriteFile(List<Suggestion> suggestionsUpdate, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (var writer = File.CreateText(filePath))
            {
                writer.WriteLine("SuggestionId`EmployeeName`SuggestionText");

                foreach (var s in suggestionsUpdate)
                {
                    writer.WriteLine("{0}`{1}`{2}", s.SuggestionId, s.EmployeeName, s.SuggestionText);
                }
            }
        }
    }
}