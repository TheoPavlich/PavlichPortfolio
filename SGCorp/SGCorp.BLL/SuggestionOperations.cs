using System;
using System.Collections.Generic;
using System.Linq;
using SGCorp.Data.Interfaces;
using SGCorp.Models;

namespace SGCorp.BLL
{
    public class SuggestionOperations
    {
        private ISuggestionRepository _suggestionRepo;

        public SuggestionOperations(ISuggestionRepository suggestionRepo)
        {
            _suggestionRepo = suggestionRepo;
        }

        public Response<Suggestion> CreateSuggestion(Suggestion suggestion)
        {
            var response = new Response<Suggestion>();

            try
            {
                int newSuggestionID;

                List<Suggestion> existingSuggestions = _suggestionRepo.GetAllSuggestions();

                if (existingSuggestions.Exists(s => !s.SuggestionId.Equals(null)))
                {
                    newSuggestionID = existingSuggestions.Max(s => s.SuggestionId);
                    newSuggestionID += 1;
                    suggestion.SuggestionId = newSuggestionID;

                    _suggestionRepo.AddSuggestion(suggestion);

                    response.Success = true;
                    response.Data = suggestion;
                }
                else
                {
                    suggestion.SuggestionId = 1;
                    response.Success = true;
                    response.Data = suggestion;
                }

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        } 
    }
}