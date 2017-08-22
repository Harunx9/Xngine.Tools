using FluentAssertions;
using System.Collections.Generic;
using Xngine.Tools.Commons.CommandLineFramework;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.CommandlineFramework.Factory
{
    public class on_create_test_command : AAATest
    {
        private CommandLineArgs args;
        private TestCommand result;

        protected override void Arrange()
        {
            args = new CommandLineArgs("test", new Dictionary<string, string>
            {
                ["option1"] = "23",
                ["option2"] = "true",
                ["option3"] = "bleee"
            });
        }

        protected override void Act()
        {
            result = CommandFactory.Create<TestCommand>(args);
        }

        [Assert]
        public void command_shoudl_not_be_null()
            => result.Should().NotBeNull();

        [Assert]
        public void option1_shoud_have_23_value()
            => result.Number.Should().Be(23);

        [Assert]
        public void option2_shoud_have_true_value()
            => result.Boolean.Should().BeTrue();

        [Assert]
        public void option3_shoud_have_bleee_value()
            => result.Text.Should().Be("bleee");
    }
}
