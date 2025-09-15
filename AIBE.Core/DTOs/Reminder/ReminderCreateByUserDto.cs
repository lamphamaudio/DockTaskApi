using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.Reminder
{
    public class ReminderCreateByUserDto
    {
        public List<int> UserIds { get; set; } = new();
        public int TasID { get; set; }
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime TriggerTime { get; set; }
    }
}
