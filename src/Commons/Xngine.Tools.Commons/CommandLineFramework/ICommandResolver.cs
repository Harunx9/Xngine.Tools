namespace Xngine.Tools.Commons.CommandLineFramework
{
    public interface ICommandResolver
    {
        IConsoleCommandHandler ResolveCommandHandler(CommandLineParsedArgs args);
        T ResolveCommandHandler<T>(string name);
    }
}
