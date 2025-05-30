using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HClHackactnWithAngular.Repositories.Entities
{
    public class UserData
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        // Staff information for directory (stretch goal #5)
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string StaffRole { get; set; } // Doctor, Nurse, etc. (stretch goal #1)
        public string Department { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Shift load tracking (stretch goal #6)
        public int WeeklyShiftLimit { get; set; } = 5;
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation property
        public User User { get; set; }
    }
}
