﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIBE.Core.Helpers
{
    public class ErrorException : Exception
    {
        public ErrorException(string message):base(message) { }
       
    }
}
