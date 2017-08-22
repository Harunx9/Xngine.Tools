using System;

namespace Xngine.Tools.Commons.CommandLineFramework.Exceptions
{
    [Serializable]
    public class RequiredOptionNotFoundException : Exception
    {
        public RequiredOptionNotFoundException()
        {
        }

        public RequiredOptionNotFoundException(string name) : base($"Required option {name} not found in args")
        {
        }

        public RequiredOptionNotFoundException(string name, Exception innerException) : base($"Required option {name} not found in args", innerException)
        {
        }
    }
}