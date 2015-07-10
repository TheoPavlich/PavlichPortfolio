using System.Collections.Generic;
using System.IO;
using System.Linq;
using SGCorp.Models;

namespace SGCorp.Data
{
    public class ResumeRepository
    {
        private static readonly List<Resume> _resumes = new List<Resume>();
        //private const string filePath = @"~/DataFiles/suggestions.txt";

        //public Resume GetById(int id, string filePath)
        //{
        //    _resumes = GetAll(filePath);

        //    foreach (var r in _resumes)
        //    {
        //        if (r.ResumeId == id)
        //            return r;
        //    }
        //    return null;
        //}

        public List<Resume> GetAll(string filePath)
        {
            if (File.Exists(filePath))
            {
                var reader = File.ReadAllLines(filePath);

                for (var i = 1; i < reader.Length; i++)
                {
                    var columns = reader[i].Split('`');

                    var resume = new Resume
                    {
                        ResumeId = int.Parse(columns[0]),
                        ApplicantName = columns[1],
                        ResumeFilePath = columns[2]
                    };
                    _resumes.Add(resume);
                }
            }
            return _resumes;
        }

        public void Add(Resume resume, string filePath)
        {
            //_resumes = GetAll(fileName);
            if (_resumes.Any())
                resume.ResumeId = _resumes.Max(r => r.ResumeId) + 1;
            else
                resume.ResumeId = 1;

            _resumes.Add(resume);

            OverwriteFile(_resumes, filePath);
        }

        public void Delete(Resume resume, string filePath)
        {
            //_resumes = GetAll(fileName);
            //_resumes.Remove(resume);
            OverwriteFile(_resumes, filePath);
        }

        private void OverwriteFile(List<Resume> resumesUpdate, string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (var writer = File.CreateText(filePath))
            {
                writer.WriteLine("ResumeId`ApplicantName`ResumeFilePath");

                foreach (var r in resumesUpdate)
                {
                    writer.WriteLine("{0}`{1}`{2}", r.ResumeId, r.ApplicantName, r.ResumeFilePath);
                }
            }
        }
    }
}