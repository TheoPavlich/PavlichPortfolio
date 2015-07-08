using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SGCorp.Models
{
    public class ResumeDatabase
    {
        private static List<Resume> resumes = new List<Resume>();

        public List<Resume> GetAll(string fileName)
        {

            if (File.Exists(fileName))
            {
                var reader = File.ReadAllLines(fileName);

                for (int i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split('`');

                    var resume = new Resume
                    {
                        ResumeID = int.Parse(columns[0]),
                        ApplicantName = columns[1],
                        ResumeFilePath = columns[2]
                    };
                    resumes.Add(resume);
                }

            }
            return resumes;
        }

        public Resume GetById(int id)
        {
            return resumes.FirstOrDefault(r => r.ResumeID == id);
        }

        public void Add(Resume resume, string fileName)
        {
            resumes = GetAll(fileName);
            if (resumes.Any())
                resume.ResumeID = resumes.Max(r => r.ResumeID) + 1;
            else
                resume.ResumeID = 1;

            resumes.Add(resume);

            OverwriteFile(resumes, fileName);
        }

        public void Delete(Resume resume, string fileName)
        {
            var resumes = GetAll(fileName);
            resumes.Remove(resume);
            OverwriteFile(resumes, fileName);
        }

        private void OverwriteFile(List<Resume> resumes, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (var writer = File.CreateText(fileName))
            {
                writer.WriteLine("ResumeId`ApplicantName`ResumeFilePath");

                foreach (var r in resumes)
                {
                    writer.WriteLine("{0}`{1}`{2}", r.ResumeID, r.ApplicantName, r.ResumeFilePath);
                }
            }
        }

    }
}