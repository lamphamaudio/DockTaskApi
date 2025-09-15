using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.Reminder
{
    public class ReminderCreateByUnitDto
    {
        public List<int> UnitIds { get; set; } = new();
        public int TaskID { get; set; }
        public string Title { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime TriggerTime { get; set; }
    }
}
