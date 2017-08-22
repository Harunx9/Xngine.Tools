using Xngine.Tools.Commons.CommandLineFramework.Attributes;

namespace Xngine.Tools.Tests.CommandlineFramework.Factory
{
    [Command("test")]
    public class TestCommand
    {
        [CommandOptionsValue("option1", DefaultValue = 32)]
        public int Number { get; set; }

        [CommandOptionsValue("option2", Required = true)]
        public bool Boolean { get; set; }

        [CommandOptionsValue("option3")]
        public string Text { get; set; }
    }
}
