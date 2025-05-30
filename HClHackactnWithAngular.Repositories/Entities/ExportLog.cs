using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HClHackactnWithAngular.Repositories.Entities
{
    public class ExportLog
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime ExportedAt { get; set; }
        public string ExportType { get; set; } // "ShiftSchedule" or "AttendanceLogs"
        public string ExportedBy { get; set; } // Username who exported
        public string FilePath { get; set; }
    }
}
