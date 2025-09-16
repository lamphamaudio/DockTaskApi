using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.ReminderUnit
{
    public class ReminderUnitDto
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public string ReminderTitle { get; set; } // Thêm trường này
    }
}