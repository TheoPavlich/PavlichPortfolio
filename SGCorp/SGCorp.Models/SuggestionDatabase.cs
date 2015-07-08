using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SGCorp.Models
{
    public class SuggestionDatabase
    {
        //private string _filePath = @"~/SGCorp/Data/DataFiles/suggestions.txt";

        List<Suggestion> suggestions = new List<Suggestion>();
        //private static List<Suggestion>  _suggestions = new List<Suggestion>();

        public List<Suggestion> GetAll(string fileName)
        {

            if (File.Exists(fileName))
            {
                var reader = File.ReadAllLines(fileName);

                for (int i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split('`');

                    var suggestion = new Suggestion
                    {
                        SuggestionId = int.Parse(columns[0]),
                        EmployeeName = columns[1],
                        SuggestionText = columns[2]
                    };
                    suggestions.Add(suggestion);
                }

            }
            return suggestions;
        }

        public void Add(Suggestion suggestion, string fileName)
        {
            suggestions = GetAll(fileName);
            if (suggestions.Any())
                suggestion.SuggestionId = suggestions.Max(s => s.SuggestionId) + 1;
            else
                suggestion.SuggestionId = 1;

            suggestions.Add(suggestion);

            OverwriteFile(suggestions, fileName);
        }


        public void Delete(int id)
        {
           suggestions.RemoveAll(s => s.SuggestionId == id);
        }

        public void Delete(Suggestion suggestion, string fileName)
        {
            var suggestions = GetAll(fileName);
            suggestions.Remove(suggestion);
            OverwriteFile(suggestions, fileName);
        }

        //public Suggestion GetById(int id)
        //{
        //    var suggestions = GetAll(fileName);
        //    return suggestions.FirstOrDefault(s => s.SuggestionId == id);
        //}

        private void OverwriteFile(List<Suggestion> suggestions, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (var writer = File.CreateText(fileName))
            {
                writer.WriteLine("SuggestionId`EmployeeName`SuggestionText");

                foreach (var s in suggestions)
                {
                    writer.WriteLine("{0}`{1}`{2}", s.SuggestionId, s.EmployeeName, s.SuggestionText);
                }
            }
        }
    }
}