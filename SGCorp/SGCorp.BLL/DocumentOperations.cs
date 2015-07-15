using System;
using System.Collections.Generic;
using SGCorp.Data;
using SGCorp.Models;

namespace SGCorp.BLL
{
    public class DocumentOperations
    {
        public Response<Document> AddDocument(Document doc, string textMapPath)
        {
            var repo = new DocumentRepository();
            var response = new Response<Document>();
            try
            {
                repo.Add(doc, textMapPath);

                response.Success = true;
                response.Data = doc;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public List<Document> GetAll(string mapPath)
        {
            var repo = new DocumentRepository();
            return repo.GetAll(mapPath);
        }
    }
}