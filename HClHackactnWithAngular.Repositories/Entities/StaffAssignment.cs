using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HClHackactnWithAngular.Repositories.Entities
{
    public class StaffAssignment
    {
        public int Id { get; set; }
        public int ShiftId { get; set; }
        public int StaffId { get; set; }
        public DateOnly ShiftDate { get; set; } // Denormalized for indexing
        public DateTime AssignedAt { get; set; }
        public string QRCodeIdentifier { get; set; } // Supports QR code generation (Goal 3)
        public bool CheckedIn { get; set; } // Tracks if staff checked in via QR code
        public DateTime? CheckInTime { get; set; }

        // Navigation properties
        public Shift Shift { get; set; }
        public User Staff { get; set; }
        public Attendance Attendance { get; set; }
    }
}
