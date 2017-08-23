using Xngine.Tools.Commons.CommandLineFramework.Attributes;

namespace Xngine.Tools.Tests.CommandlineFramework
{
    [Command("test", Alias = "t")]
    public class TestCommand
    {
        [CommandOptionsValue("option1", DefaultValue = 32)]
        public int Number { get; set; }

        [CommandOptionsValue("option2", Required = true)]
        public bool Boolean { get; set; }

        [CommandOptionsValue("option3", Alias = "o3")]
        public string Text { get; set; }
    }
}
