using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.DTOs.Paging
{
    public class ResultDto<T>
    {
        public Meta Meta { get; set; }
        public List<T> Datas { get; set; }

    }
}
