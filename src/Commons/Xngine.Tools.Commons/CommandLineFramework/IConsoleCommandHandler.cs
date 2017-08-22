using System.IO;

namespace Xngine.Tools.Commons.CommandLineFramework
{
    public interface IConsoleCommandHandler
    {
        void ExecuteFromParsedArgs(CommandLineArgs args, TextWriter @out);
    }

    public abstract class ConsoleCommandHandler<T> : IConsoleCommandHandler
        where T : class, new()
    {

        public void ExecuteFromParsedArgs(CommandLineArgs args, TextWriter @out)
        {
            T command = CommandFactory.Create<T>(args);
            Execute(command, @out);
        }

        public abstract void Execute(T command, TextWriter @out);
    }
}
