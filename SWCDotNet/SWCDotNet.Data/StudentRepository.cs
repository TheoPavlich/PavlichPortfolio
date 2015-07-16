using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SWCDotNet.Models;

namespace SWCDotNet.Data
{
    public class StudentRepository
    {
        public List<Student> GetStudents()
        {
            var students = new List<Student>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetStudents", cn) {CommandType = CommandType.StoredProcedure};

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var student = new Student
                        {
                            StudentId = (int) dr["StudentID"],
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            State = dr["State"].ToString()
                        };
                        students.Add(student);
                    }
                }
            }
            return students;
        }

        public Student GetStudentById(int id)
        {
            var student = new Student();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetStudentByID", cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@StudentID", id);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        student.FirstName = dr["FirstName"].ToString();
                        student.LastName = dr["LastName"].ToString();
                        student.State = dr["State"].ToString();
                        student.StudentId = id;
                    }
                }
            }
            return student;
        }

        public void RemoveStudentFromCohort(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("RemoveStudent", cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@StudentID", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddStudentToCohort(Student student)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("AddStudent", cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@State", student.State);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("UpdateStudent", cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@StudentID", student.StudentId);
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@State", student.State);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}