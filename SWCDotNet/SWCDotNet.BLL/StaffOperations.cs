using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWCDotNet.Data;
using SWCDotNet.Models;

namespace SWCDotNet.BLL
{
    public class StaffOperations
    {
        public List<Staff> GetStaff()
        {
            var repo = new StaffRepository();
            return repo.GetStaff();
        }

        public Staff GetStaffById(int id)
        {
            var repo = new StaffRepository();
            return repo.GetStaffById(id);
        }

        public void AddStaffMember(Staff staff)
        {
            var repo = new StaffRepository();
            repo.AddStaffMember(staff);
        }

        public void RemoveStaffMember(int id)
        {
            var repo = new StaffRepository();
            repo.RemoveStaffMember(id);
        }

        public void UpdateStaff(Staff staff)
        {
            var repo = new StaffRepository();
            repo.UpdateStaff(staff);
        }
    }
}
