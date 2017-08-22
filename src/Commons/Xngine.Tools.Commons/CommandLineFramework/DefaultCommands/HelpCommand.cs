using Xngine.Tools.Commons.CommandLineFramework.Attributes;

namespace Xngine.Tools.Commons.CommandLineFramework.DefaultCommands
{
    [Command("help", Alias = "h", HelpText = "Help for cli")]
    public class HelpCommand
    {
        [CommandOptionsValue("command", Alias = "c", HelpText = "Type command name to get detailed help")]
        public string CommandName { get; set; }

        public string ErrorMessage { get; set; }
    }
}
