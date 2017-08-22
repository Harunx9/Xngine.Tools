using Autofac;
using System;
using Xngine.Tools.Commons.CommandLineFramework;
using Xngine.Tools.Commons.Ioc;

namespace Xngine.Packer.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder
                .RegisterDependencies(AssemblyFinder.GetCurrentAssemblyWithDependencies());
            containerBuilder.RegisterConsoleCommands();

            var app = new CommandLineApplication(
                new AutofacCommandResolver(containerBuilder.Build()), Console.Out);

            app.Run(args);
        }
    }
}