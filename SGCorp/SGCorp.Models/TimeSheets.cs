using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCorp.Models
{
    public class TimeSheets
    {
        public int TimeId { get; set; }
        public DateTime Date { get; set; }
        public decimal Hours { get; set; }
        public int EmpId { get; set; }
    }
}
