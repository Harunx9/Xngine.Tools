using System;

namespace Xngine.Packer.Model.CommandsHandlers.Exceptions
{
    [Serializable]
    internal class AnimationFileNameNotMatchPatternException : Exception
    {
        public AnimationFileNameNotMatchPatternException():base("File name not match with pattern")
        {
        }

        public AnimationFileNameNotMatchPatternException(string message) : base(message)
        {
        }

        public AnimationFileNameNotMatchPatternException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}