using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using SGCorp.Models;

namespace SGCorp.Data
{
    public class TimesheetRepository
    {
        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetAllEmployees", cn) {CommandType = CommandType.StoredProcedure};

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var employee = new Employee {EmpId = (int) dr["EmpID"]};
                        if (dr["FirstName"] != DBNull.Value)
                        {
                            employee.FirstName = dr["FirstName"].ToString();
                        }
                        if (dr["LastName"] != DBNull.Value)
                        {
                            employee.LastName = dr["LastName"].ToString();
                        }
                        if (dr["HireDate"] != DBNull.Value)
                        {
                            employee.HireDate = (DateTime) dr["HireDate"];
                        }

                        employee.HoursSum = SumHours(employee.EmpId);
                        employees.Add(employee);
                    }
                }
            }
            return employees;
        }

        public List<Timesheet> GetAllTimesheets()
        {
            var timesheets = new List<Timesheet>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetAllTimesheets", cn) { CommandType = CommandType.StoredProcedure };

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var timesheet = new Timesheet()
                        {
                            TimeId = (int) dr["TimeID"],
                            EmpId = (int) dr["EmpID"]
                        };
                        if (dr["Hours"] != DBNull.Value)
                        {
                            timesheet.Hours = (int)dr["Hours"];
                        }
                        if (dr["Date"] != DBNull.Value)
                        {
                            timesheet.Date = (DateTime)dr["HireDate"];
                        }
                        timesheets.Add(timesheet);
                    }
                }
            }
            return timesheets;
        }

        public Employee GetEmployeeById(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmpID", id);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var employee = new Employee()
                        {
                            EmpId = (int) dr["EmpID"],
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            HireDate = (DateTime) dr["HireDate"],
                            HoursSum = SumHours(id)
                        };
                        return employee;
                    }
                }
                return null;
            }
        }

        public List<Timesheet> GetTimesheetsByEmployeeId(int id)
        {
            var timesheets = new List<Timesheet>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("GetTimesheetsByEmployeeID", cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@EmpID", id);

                cn.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var timesheet = new Timesheet()
                        {
                            TimeId = (int)dr["TimeID"],
                            EmpId = id
                         };
                        if (dr["Hours"] != DBNull.Value)
                        {
                            timesheet.Hours = (int)dr["Hours"];
                        }
                        if (dr["Date"] != DBNull.Value)
                        {
                            timesheet.Date = (DateTime)dr["HireDate"];
                        }
                        timesheets.Add(timesheet);
                    }
                }
            }
            return timesheets;
        } 

        public void AddTimesheet(Timesheet timesheet)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("AddTimesheet", cn) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@Date", timesheet.Date);
                cmd.Parameters.AddWithValue("@Hours", timesheet.Hours);
                cmd.Parameters.AddWithValue("@EmpID", timesheet.EmpId);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTimesheet(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("DeleteTimesheet", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@TimeID", id);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public decimal SumHours(int id)
        {
            decimal sum = 0;
            //Called by GetAllEmployees
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                var cmd = new SqlCommand("SumTimesheets", cn) {CommandType = CommandType.StoredProcedure};

                cmd.Parameters.AddWithValue("@EmpID", id);
                //SqlParameter param = new SqlParameter("@HoursSum",SqlDbType.Int){Direction = ParameterDirection.Output};
                //cmd.Parameters.Add(param);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sum = dr[0] is DBNull ? 0 : (decimal)dr[0];
                    }
                } 
            }
            return sum;
        }
    }
}