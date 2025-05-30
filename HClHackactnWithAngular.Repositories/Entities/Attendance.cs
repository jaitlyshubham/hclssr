using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HClHackactnWithAngular.Repositories.Entities
{
    // Attendance.cs
    public class Attendance
    {
        public int Id { get; set; }
        public int StaffAssignmentId { get; set; }
        public AttendanceStatus Status { get; set; }
        public DateTime MarkedAt { get; set; }
        public string Notes { get; set; }

        // Navigation property
        public StaffAssignment StaffAssignment { get; set; }
    }
}
