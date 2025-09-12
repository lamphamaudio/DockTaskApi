using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.Paging
{
    public class Meta
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCounts { get; set; }
        public int TotalPages { get; set; }
    }
}
