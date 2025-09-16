using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.Position
{
    public class PositionRequest
    {
        [Required]
        [MaxLength(1000, ErrorMessage ="Max leng")]
        [MinLength(3, ErrorMessage = "Min leng")]
        public string PositionName { get; set; } = null!;
    }
}
