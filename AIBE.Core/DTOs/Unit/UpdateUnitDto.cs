using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.Unit
{
    public class UpdateUnitDto
    {
        public int ogId { get; set; }
        public string unitName { get; set; } = string.Empty;
        public string type { get; set; } = string.Empty;

    }
}
