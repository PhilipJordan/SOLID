using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverMunged
{
    public class CrashException : Exception
    {
        public CrashException(String message)
            : base(message)
        { }
    }
}
