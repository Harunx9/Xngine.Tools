using Autofac;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xngine.Tools.Commons.CommandLineFramework;
using Xngine.Tools.Commons.Ioc;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.CommandlineFramework.CommandResolver
{
    public class on_resolve_command_handler_from_alias : AAATest
    {
        private CommandLineParsedArgs args;
        private AutofacCommandResolver resolver;
        private IConsoleCommandHandler result;

        protected override void Arrange()
        {
            args = new CommandLineParsedArgs("test",
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
            result = resolver.ResolveCommandHandler(args);
        }

        [Assert]
        public void command_handler_shoudl_not_be_null()
            => result.Should().NotBeNull();

        [Assert]
        public void command_handler_should_be_of_type_TestCommandHandler()
            => result.Should().BeOfType<TestCommandHandler>();
    }
}
