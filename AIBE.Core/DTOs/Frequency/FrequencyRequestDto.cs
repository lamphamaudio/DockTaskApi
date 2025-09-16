using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIBE.Core.DTOs.FrequencyDetail;

namespace AIBE.Core.DTOs.Frequency
{
    public class FrequencyRequestDto
    {
        public int FrequencyId { get; set; }
        public string FrequencyType { get; set; } = null!;
        public Frequencydetail? frequencydetail { get; set; }
        public int IntervalValue { get; set; }
    }
}
