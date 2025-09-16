using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIBE.Core.DTOs.Frequency;

namespace AIBE.Core.DTOs.Task
{
    public class TaskRequestDto
    {
        [Required(ErrorMessage = "Title không được để trống")]
        [StringLength(200, ErrorMessage = "Title không được vượt quá 200 ký tự")]
        public string Title { get; set; } = null!;

        [StringLength(1000, ErrorMessage = "Description không được vượt quá 1000 ký tự")]
        public string? Description { get; set; }

        public int? AssignerId { get; set; }

        public int? AssigneeId { get; set; }

        public int? OrgId { get; set; }

        public int? PeriodId { get; set; }

        public int? AttachedFile { get; set; }

        public string? Status { get; set; }

        public string? Priority { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? DueDate { get; set; }

        public int? UnitId { get; set; }

        public FrequencyRequestDto? FrequencyDto { get; set; }

        public int? Percentagecomplete { get; set; }

        public int? ParentTaskId { get; set; }
    }
}
