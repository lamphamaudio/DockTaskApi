using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.FrequencyDetail
{
    public class Frequencydetail
    {
        public int FrequencyId { get; set; }
        public int? DayOfWeek { get; set; }
        public int? DayOfMonth { get; set; }
    }
}
