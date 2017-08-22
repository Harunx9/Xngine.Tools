using System;

namespace Xngine.Tools.Commons.CommandLineFramework.Exceptions
{
    [Serializable]
    public class TooManyCommandsWithSameNameException : Exception
    {
        public TooManyCommandsWithSameNameException()
        {
        }

        public TooManyCommandsWithSameNameException(string commandName) : base($"Command {commandName} is registerd multiple times")
        {
        }

        public TooManyCommandsWithSameNameException(string commandName, Exception innerException) : base($"Command {commandName} is registerd multiple times", innerException)
        {
        }
    }
}