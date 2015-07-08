using System.Collections.Generic;
using System.Linq;

namespace SGCorp.Models
{
    public class ResumeDatabase
    {
        private static List<Resume> resumes = new List<Resume>();

        public List<Resume> GetAll()
        {
            return resumes;
        }

        public void Add(Resume resume)
        {
            if (resumes.Any())
                resume.ResumeID = resumes.Max(r => r.ResumeID) + 1;
            else
                resume.ResumeID = 1;

            resumes.Add(resume);
        }

        public Resume GetById(int id)
        {
            return resumes.FirstOrDefault(r => r.ResumeID == id);
        }
    }
}