using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCDotNet.Data;
using SWCDotNet.Models;

namespace SWCDotNet.BLL
{
    class StudentOperations
    {
        public List<Student> GetStudents()
        {
            var repo = new StudentRepository();
            return repo.GetStudents();
        }

        public Student GetStudentById(int id)
        {
            var repo = new StudentRepository();
            return repo.GetStudentById(id);
        } 
    }
}
