using Autofac;
using System;
using System.Linq;
using System.Reflection;
using Xngine.Tools.Commons.CommandLineFramework;
using Xngine.Tools.Commons.CommandLineFramework.Attributes;
using Xngine.Tools.Commons.CommandLineFramework.Exceptions;

namespace Xngine.Tools.Commons.Ioc
{
    public sealed class AutofacCommandResolver : ICommandResolver
    {
        private readonly IContainer _container;

        public AutofacCommandResolver(IContainer container)
        {
            _container = container;
        }

        public IConsoleCommandHandler ResolveCommandHandler(CommandLineArgs args)
        {
            try
            {
                var commandType = GetCommandType(args.CommandName);
                return _container.ResolveNamed(args.CommandName, commandType) as IConsoleCommandHandler;
            }
            catch (Exception ex)
            {
                throw new CommandNotFoundException(args.CommandName, ex);
            }
        }

        public T ResolveCommandHandler<T>(string name)
        {
            return _container.ResolveNamed<T>(name);
        }

        private Type GetCommandType(string name)
        {
            return AssemblyFinder.GetCurrentAssemblyWithDependencies()
                 .SelectMany(x => x.GetTypes()
                     .Where(
                        t => t.GetTypeInfo().GetCustomAttribute<CommandHandlerAttribute>() != null))
                 .FirstOrDefault(x => x.GetTypeInfo()
                         .GetCustomAttribute<CommandHandlerAttribute>().CommandName == name);
        }
    }
}
