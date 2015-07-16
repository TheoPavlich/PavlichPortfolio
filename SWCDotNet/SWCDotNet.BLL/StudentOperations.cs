using System.Collections.Generic;
using SWCDotNet.Data;
using SWCDotNet.Models;

namespace SWCDotNet.BLL
{
    public class StudentOperations
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

        public void AddStudentToCohort(Student student)
        {
            var repo = new StudentRepository();
            repo.AddStudentToCohort(student);
        }

        public void RemoveStudentFromCohort(int id)
        {
            var repo = new StudentRepository();
            repo.RemoveStudentFromCohort(id);
        }

        public void UpdateStudent(Student student)
        {
            var repo = new StudentRepository();
            repo.UpdateStudent(student);
        }
    }
}