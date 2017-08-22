using FluentAssertions;
using Xngine.Tools.Commons.CommandLineFramework;
using Xngine.Tools.Commons.CommandLineFramework.Exceptions;
using Xngine.Tools.Tests.BaseFramework;
using Xunit;
using System;

namespace Xngine.Tools.Tests.CommandlineFramework.Parser
{
    public class on_parse_empty_args : AAATest
    {
        private string[] args;
        private CommandLineArgsParser parser;
        private Exception exception;

        protected override void Arrange()
        {
            args = new string[0];
            parser = new CommandLineArgsParser("--", new[] { '=', ':' }, 0);
        }

        protected override void Act()
        {
            exception = Record.Exception(() =>  parser.Parse(args));
        }

        [Assert]
        public void exeption_shoudl_be_of_type_EmptyArgsException()
            => exception.Should().BeOfType<EmptyArgsException>();
    }
}
