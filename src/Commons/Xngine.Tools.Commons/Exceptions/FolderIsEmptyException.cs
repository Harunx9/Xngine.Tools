using System;

namespace Xngine.Tools.Commons.Exceptions
{
    [Serializable]
    public class FolderIsEmptyException : Exception
    {
        public FolderIsEmptyException() : base("Nothing found in input directory") { }
        public FolderIsEmptyException(string message) : base(message) { }
        public FolderIsEmptyException(string message, Exception inner) : base(message, inner) { }
    }
}
