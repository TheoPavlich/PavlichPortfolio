using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGCorp.Models;

namespace SGCorp.Data
{
    public class SuggestionRepository
    {
        private const string FilePath = @"~/DataFiles/suggestions.txt";

        public Suggestion GetSuggestion(int id)
        {
            List<Suggestion> suggestions = GetAllSuggestions();

            foreach (var s in suggestions)
            {
                if (s.SuggestionId == id)
                    return s;
            }
            return null;
        }

        public List<Suggestion> GetAllSuggestions()
        {
            List<Suggestion> suggestions = new List<Suggestion>();

            var reader = File.ReadAllLines(FilePath);

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var suggestion = new Suggestion();

                suggestion.EmployeeName = columns[0];
                suggestion.SuggestionText = columns[1];
                suggestion.SuggestionId = int.Parse(columns[2]);

                suggestions.Add(suggestion);


            }
            return suggestions;
        }

        public void AddSuggestion(Suggestion addSuggestion)
        {
            List<Suggestion> existingSuggestions = GetAllSuggestions();

            existingSuggestions.Add(addSuggestion);

            OverwriteFile(existingSuggestions);
        }

        public void OverwriteFile(List<Suggestion> allSuggestions)
        {
            File.Delete(FilePath);

            using (var writer = File.CreateText(FilePath))
            {
                writer.WriteLine("EmployeeName, SuggestionText, SuggestionID");

                foreach (var suggestion in allSuggestions)
                {
                    writer.WriteLine("{0},{1},{2},", suggestion.EmployeeName, suggestion.SuggestionText, suggestion.SuggestionId);
                }
            }
        }
    }
}
