using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.Org
{
    public class OrgRequestDTO
    {
        public string OrgName { get; set; } = null;
        public int? parentOrgId { get; set; }

    }
}
