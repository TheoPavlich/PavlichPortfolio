using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGCorp.UI.Models
{
    public class ApplicantDatabase
    {
        private static List<Applicant> _applicants = new List<Applicant>();

        public List<Applicant> GetAll()
        {
            return _applicants;
        }

        public void Add(Applicant applicant)
        {
            if (_applicants.Any())
                applicant.ApplicantID = _applicants.Max(a => a.ApplicantID) + 1;
            else
                applicant.ApplicantID = 1;

            _applicants.Add(applicant);
        }

        public Applicant GetById(int id)
        {
            return _applicants.FirstOrDefault(a => a.ApplicantID == id);
        }
    }
}