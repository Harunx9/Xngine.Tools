using System;

namespace Xngine.Tools.Commons.CommandLineFramework.Exceptions
{
    [Serializable]
    public class EmptyArgsException : Exception
    {
        public EmptyArgsException() : this("Arguments are empty")
        {
        }

        public EmptyArgsException(string message) : base(message)
        {
        }

        public EmptyArgsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}