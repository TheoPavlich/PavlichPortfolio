using System.Collections.Generic;
using SGCorp.Models;

namespace SGCorp.Data.Interfaces
{
    public interface ISuggestionRepository
    {
        Suggestion GetSuggestion(int id);
        List<Suggestion> GetAllSuggestions();
        void AddSuggestion(Suggestion addSuggestion);
        void OverwriteFile(List<Suggestion> allSuggestions);
        
    }
}