using System;
using System.Collections.Generic;
using SGCorp.Data;
using SGCorp.Models;

namespace SGCorp.BLL
{
    public class ResumeOperations
    {
        public Response<Resume> AddResume(Resume resume, string textMapPath)
        {
            var repo = new ResumeRepository();
            var response = new Response<Resume>();
            try
            {
                repo.Add(resume, textMapPath);

                response.Success = true;
                response.Data = resume;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public List<Resume> GetAll(string mapPath)
        {
            var repo = new ResumeRepository();
            return repo.GetAll(mapPath);
        }
    }
}