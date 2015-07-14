using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCDotNet.Models;

namespace SWCDotNet.Data
{
    public class StudentRepository
    {
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetStudents", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var student = new Student();
                        student.StudentId = (int) dr["StudentID"];
                        student.FirstName = dr["FirstName"].ToString();
                        student.LastName = dr["LastName"].ToString();
                        student.State = dr["State"].ToString();
                        students.Add(student);
                    }
                }
            }
            return students;
        }

        public Student GetStudentById(int id)
        {
            Student student = new Student();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetStudentByID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
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
                var cmd = new SqlCommand("RemoveStudent", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddStudentToCohort(Student student)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("AddStudent", cn);
                cmd.CommandType = CommandType.StoredProcedure;
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
                var cmd = new SqlCommand("UpdateStudent", cn);
                cmd.CommandType = CommandType.StoredProcedure;
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
