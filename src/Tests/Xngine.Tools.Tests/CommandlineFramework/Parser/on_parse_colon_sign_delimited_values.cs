using FluentAssertions;
using System.Linq;
using Xngine.Tools.Commons.CommandLineFramework;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.CommandlineFramework.Parser
{
    public class on_parse_colon_sign_delimited_values : AAATest
    {
        private string[] args;
        private CommandLineArgsParser parser;
        private CommandLineParsedArgs result;

        protected override void Arrange()
        {
            args = new[] { "command", "--option1:32", "--option2:desc" };
            parser = new CommandLineArgsParser("--", new[] { '=', ':' }, 0);
        }

        protected override void Act()
        {
            result = parser.Parse(args);
        }

        [Assert]
        public void command_name_should_be_command()
             => result.CommandName.Should().Be("command");

        [Assert]
        public void first_option_should_be_option1_and_have_32_value()
        {
            var keyVal = result.CommandOptionsValues.First();
            keyVal.Key.Should().Be("option1");
            keyVal.Value.Should().Be("32");
        }

        [Assert]
        public void second_option_should_be_option2_and_have_desc_value()
        {
            var keyVal = result.CommandOptionsValues.Last();
            keyVal.Key.Should().Be("option2");
            keyVal.Value.Should().Be("desc");
        }
    }
}
