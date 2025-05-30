using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HClHackactnWithAngular.Repositories.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // "Admin" or "Staff"

        // Navigation property
        public ICollection<UserData> UserData { get; set; }
        public ICollection<StaffAssignment> StaffAssignments { get; set; }
    }
}
