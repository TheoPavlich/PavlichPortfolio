using System;
using System.ComponentModel.DataAnnotations;

namespace SGCorp.Models
{
    public class Timesheet
    {
        public int TimeId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public decimal Hours { get; set; }
        public int EmpId { get; set; }
    }
}