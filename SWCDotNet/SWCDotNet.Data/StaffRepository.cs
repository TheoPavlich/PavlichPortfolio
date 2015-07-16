using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SWCDotNet.Models;

namespace SWCDotNet.Data
{
    public class StaffRepository
    {
        public List<Staff> GetStaff()
        {
            var staffMembers = new List<Staff>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetStaff", cn) {CommandType = CommandType.StoredProcedure};

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var staff = new Staff
                        {
                            StaffId = (int) dr["StaffID"],
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Role = dr["Role"].ToString()
                        };
                        staffMembers.Add(staff);
                    }
                }
            }
            return staffMembers;
        }

        public Staff GetStaffById(int id)
        {
            var staff = new Staff();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetStaffByID", cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@StaffID", id);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        staff.FirstName = dr["FirstName"].ToString();
                        staff.LastName = dr["LastName"].ToString();
                        staff.Role = dr["Role"].ToString();
                        staff.StaffId = id;
                    }
                }
            }
            return staff;
        }

        public void RemoveStaffMember(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("RemoveStaff", cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@StaffID", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddStaffMember(Staff staff)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("AddStaff", cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@FirstName", staff.FirstName);
                cmd.Parameters.AddWithValue("@LastName", staff.LastName);
                cmd.Parameters.AddWithValue("@Role", staff.Role);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStaff(Staff staff)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("UpdateStaff", cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@StaffID", staff.StaffId);
                cmd.Parameters.AddWithValue("@FirstName", staff.FirstName);
                cmd.Parameters.AddWithValue("@LastName", staff.LastName);
                cmd.Parameters.AddWithValue("@Role", staff.Role);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}