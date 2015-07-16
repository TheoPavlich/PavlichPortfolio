using System;

namespace SGCorp.Models
{
    public class Timesheet
    {
        public int TimeId { get; set; }
        public DateTime Date { get; set; }
        public decimal Hours { get; set; }
        public int EmpId { get; set; }
    }
}