using System;
using System.Collections.Generic;
using SGCorp.Data;
using SGCorp.Models;

namespace SGCorp.BLL
{
    public class SuggestionOperations
    {
        public Response<Suggestion> Add(Suggestion suggestion, string mapPath)
        {
            var repo = new SuggestionRepository();
            var response = new Response<Suggestion>();

            try
            {
                repo.Add(suggestion, mapPath);

                response.Success = true;
                response.Data = suggestion;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public List<Suggestion> GetAll(string mapPath)
        {
            var repo = new SuggestionRepository();
            return repo.GetAllSuggestions(mapPath);
        }

        public Response<Suggestion> Delete(int id, string mapPath)
        {
            var repo = new SuggestionRepository();
            var response = new Response<Suggestion>();
            var suggestion = repo.GetSuggestion(id, mapPath);

            try
            {
                repo.Delete(suggestion, mapPath);

                response.Success = true;
                response.Data = suggestion;
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