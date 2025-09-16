using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.Task
{
    public class TaskSearchDto
    {
        public int TaskId { get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public int? AssignerId { get; set; }

        public int? AssigneeId { get; set; }
        public DateOnly? StartDate { get; set; }

        public DateOnly? DueDate { get; set; }
        public string? Status { get; set; }
    }
}
