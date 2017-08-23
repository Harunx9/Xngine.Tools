using FluentAssertions;
using System;
using System.Collections.Generic;
using Xngine.Tools.Commons.CommandLineFramework;
using Xngine.Tools.Commons.CommandLineFramework.Exceptions;
using Xngine.Tools.Tests.BaseFramework;
using Xunit;

namespace Xngine.Tools.Tests.CommandlineFramework.Factory
{
    public class on_create_test_command_with_error : AAATest
    {
        private CommandLineParsedArgs args;
        private Exception exception;

        protected override void Arrange()
        {
            args = new CommandLineParsedArgs("test", new Dictionary<string, string>
            {
                ["option1"] = "23",
                ["option3"] = "bleee"
            });
        }

        protected override void Act()
        {
             exception = Record.Exception(() => CommandFactory.Create<TestCommand>(args));
        }

        [Assert]
        public void exception_should_be_of_type_RequiredOptionNotFoundException()
            => exception.Should().BeOfType<RequiredOptionNotFoundException>();
    }
}
