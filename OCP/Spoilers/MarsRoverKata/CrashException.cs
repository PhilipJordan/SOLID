using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverKata
{
    public class CrashException : Exception
    {
        public CrashException(String message)
            : base(message)
        { }
    }
}
