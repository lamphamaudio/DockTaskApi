using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.Helpers
{
    internal class ApiResponse
    {
        public int StatusCode { get; set; }
        public object Message { get; set; }
        public object? Data { get; set; }
    }
}
