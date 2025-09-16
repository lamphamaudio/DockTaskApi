using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.Period
{
    public class UpdatePeriodDto
    {
        public string name { get; set; } = string.Empty;
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }
    }
}
