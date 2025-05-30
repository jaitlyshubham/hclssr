using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HClHackactnWithAngular.Repositories.Entities
{
    public class Shift
    {
        public int Id { get; set; }
        public DateOnly ShiftDate { get; set; }
        public ShiftType Type { get; set; }
        public int Capacity { get; set; }

        // Navigation property
        public ICollection<StaffAssignment> StaffAssignments { get; set; }
        public int MinimumStaffRequired { get; set; }
        public bool IsUnderstaffed => StaffAssignments?.Count < MinimumStaffRequired;
        public bool IsOverstaffed => StaffAssignments?.Count > Capacity;
        public int WeekNumber { get; set; }
    }
}
