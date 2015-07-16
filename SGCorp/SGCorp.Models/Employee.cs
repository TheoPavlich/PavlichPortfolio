using System;

namespace SGCorp.Models
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime HireDate { get; set; }
        public decimal HoursSum { get; set; }
    }
}