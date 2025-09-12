using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.Org
{
    public class OrgResponseDTO
    {
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public int ParentOrgId { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
