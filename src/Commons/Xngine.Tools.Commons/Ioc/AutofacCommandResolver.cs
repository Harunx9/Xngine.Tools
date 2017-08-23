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

        public IConsoleCommandHandler ResolveCommandHandler(CommandLineParsedArgs args)
        {
            try
            {
                var commandName = GetQualifiedCommandName(args.CommandName);
                var commandType = GetCommandType(commandName);
                return _container.ResolveNamed(commandName, commandType) as IConsoleCommandHandler;
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

        private string GetQualifiedCommandName(string commandName)
        {
            var commandType = AssemblyFinder
                .GetCurrentAssemblyWithDependencies()
                .SelectMany(x => x.GetTypes()
                    .Where(t => t.GetTypeInfo().GetCustomAttribute<CommandAttribute>() != null))
                .FirstOrDefault(x =>
                    x.GetTypeInfo().GetCustomAttribute<CommandAttribute>().Name == commandName ||
                    x.GetTypeInfo().GetCustomAttribute<CommandAttribute>().Alias == commandName
                );

            string retName = string.Empty;
            if (commandType != null)
                retName = commandType.GetTypeInfo().GetCustomAttribute<CommandAttribute>().Name;

            return retName;
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
