namespace HClHackactnWithAngular.Server.Model
{
    public class UserDataDto
    {
        public int? Id { get; set; } // Optional, for updates
        public int? UserId { get; set; } // Optional, for association

        // Staff information
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StaffRole { get; set; } // Doctor, Nurse, etc.
        public string Department { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Shift load tracking
        public int WeeklyShiftLimit { get; set; } = 5;
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
