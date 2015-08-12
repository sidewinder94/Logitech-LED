using System;

namespace Logitech_LED
{
    [Serializable]
    public class LedNotInitializedException : Exception
    {
        public LedNotInitializedException() :
            base("The Logitech LED SDK must be Initialized prior to any method use")
        {
        }
        public LedNotInitializedException(string message)
            : base(message)
        {
        }
        public LedNotInitializedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}