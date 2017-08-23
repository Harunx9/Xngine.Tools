using Autofac;
using FluentAssertions;
using System.Collections.Generic;
using Xngine.Tools.Commons.CommandLineFramework;
using Xngine.Tools.Commons.Ioc;
using Xngine.Tools.Tests.BaseFramework;
using Xunit;
using System;
using Xngine.Tools.Commons.CommandLineFramework.Exceptions;

namespace Xngine.Tools.Tests.CommandlineFramework.CommandResolver
{
    public class on_try_resolve_not_registerd_command : AAATest
    {
        private CommandLineArgs args;
        private AutofacCommandResolver resolver;
        private Exception exception;

        protected override void Arrange()
        {
            args = new CommandLineArgs("tdes",
            new Dictionary<string, string>
            {
                ["option1"] = "23",
                ["option2"] = "true",
                ["option3"] = "bleee"
            });
            var builder = new ContainerBuilder();
            builder.RegisterConsoleCommands();

            resolver = new AutofacCommandResolver(builder.Build());
        }

        protected override void Act()
        {
            exception = Record.Exception(() => resolver.ResolveCommandHandler(args));
        }

        [Assert]
        public void exception_shoudl_be_of_type_CommandNotFoundException()
            => exception.Should().BeOfType<CommandNotFoundException>();
    }
}
