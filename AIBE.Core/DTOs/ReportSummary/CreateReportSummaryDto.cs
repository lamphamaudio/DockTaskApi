using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.ReportSummary
{
    public class CreateReportSummaryDto
    {
        public int? TaskId { get; set; }

        public int? PeriodId { get; set; }

        public string? Summary { get; set; }

        public int? CreatedBy { get; set; }

        public int? ReportFile { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}