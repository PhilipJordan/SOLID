using System;

namespace MarsRoverKata
{
    public class CrashException : Exception
    {
        public CrashException(String message)
            : base(message)
        { }
    }
}
