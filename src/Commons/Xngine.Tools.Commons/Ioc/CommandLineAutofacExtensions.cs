using Autofac;
using System;
using System.Linq;
using System.Reflection;
using Xngine.Tools.Commons.CommandLineFramework.Attributes;

namespace Xngine.Tools.Commons.Ioc
{
    public static class CommandLineAutofacExtensions
    {
        public static void RegisterConsoleCommands(this ContainerBuilder containerBuilder)
        {
            Type[] commandsToRegister = AssemblyFinder
                .GetCurrentAssemblyWithDependencies()
                .SelectMany(x => x.GetTypes()
                    .Where(t => t.GetTypeInfo()
                        .GetCustomAttribute<CommandHandlerAttribute>() != null))
                .ToArray();

            foreach (var command in commandsToRegister)
            {
                var commandAttribute = command.GetTypeInfo().GetCustomAttribute<CommandHandlerAttribute>();
                containerBuilder.RegisterType(command).Named(commandAttribute.CommandName, command);
            }
        }
    }
}
