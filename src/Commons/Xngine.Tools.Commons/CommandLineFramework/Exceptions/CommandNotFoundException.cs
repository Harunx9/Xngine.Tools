using System;

namespace Xngine.Tools.Commons.CommandLineFramework.Exceptions
{
    [Serializable]
    public class CommandNotFoundException : Exception
    {
        public CommandNotFoundException()
        {
        }

        public CommandNotFoundException(string name) : base($"Command {name} not found")
        {
        }

        public CommandNotFoundException(string name, Exception innerException) : base($"Command {name} not found", innerException)
        {
        }
    }
}