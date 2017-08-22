namespace Xngine.Tools.Commons.CommandLineFramework
{
    public interface ICommandResolver
    {
        IConsoleCommandHandler ResolveCommandHandler(CommandLineArgs args);
        T ResolveCommandHandler<T>(string name);
    }
}
