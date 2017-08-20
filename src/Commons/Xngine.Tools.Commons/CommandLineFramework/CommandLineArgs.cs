using System.Collections.Generic;

namespace Xngine.Tools.Commons.CommandLineFramework
{
    public class CommandLineArgs
    {
        public string CommandName { get; }
        public Dictionary<string, string> CommandOptionsValues { get; }

        public CommandLineArgs(string commandName, 
            Dictionary<string, string> commandOptionsValues)
        {
            CommandName = commandName;
            CommandOptionsValues = commandOptionsValues;
        }

        string GetValueFor(string option)
        {
            return CommandOptionsValues[option];
        }
    }
}
