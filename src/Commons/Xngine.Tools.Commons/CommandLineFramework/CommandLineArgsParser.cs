using System.Collections.Generic;
using System.Linq;
using Xngine.Tools.Commons.CommandLineFramework.Exceptions;

namespace Xngine.Tools.Commons.CommandLineFramework
{
    public class CommandLineArgsParser
    {
        private readonly string _argDelimiter;
        private readonly char[] _valueDelimiters;
        private readonly int _commandIndexPlacement;

        public CommandLineArgsParser(
            string argDelimiter,
            char[] valueDelimiters,
            int commandIndexPlacement)
        {
            _argDelimiter = argDelimiter;
            _valueDelimiters = valueDelimiters;
            _commandIndexPlacement = commandIndexPlacement;
        }

        public CommandLineParsedArgs Parse(string[] args)
        {
            if (args.Any() == false)
                throw new EmptyArgsException();

            string commandName = ParseCommandName(args);
            Dictionary<string, string> options = ParseCommandOptions(args);

            return new CommandLineParsedArgs(commandName, options);
        }

        private Dictionary<string, string> ParseCommandOptions(string[] args)
        {
            args = args.Skip(1).ToArray();
            var options = new Dictionary<string, string>();
            string curretnOption = string.Empty;
            string currentValue = string.Empty;

            foreach (var arg in args)
            {
                bool removeOption = true;
                bool addToDict = true;

                var delimiter = _valueDelimiters
                    .FirstOrDefault(arg.Contains);

                if (default(char) != delimiter)
                {
                    curretnOption = arg
                        .Split(delimiter)
                        .First()
                        .Replace(_argDelimiter, "");

                    currentValue = arg
                        .Split(delimiter)
                        .Last();
                }
                else
                {
                    if (arg.Contains(_argDelimiter))
                    {
                        curretnOption = arg.Replace(_argDelimiter, "");
                        removeOption = false;
                        addToDict = false;
                    }

                    if (curretnOption != string.Empty &&
                        arg.Contains(_argDelimiter) == false)
                    {
                        currentValue = arg;
                    }
                }

                if (addToDict)
                    options.Add(curretnOption, currentValue);

                if (removeOption)
                    curretnOption = string.Empty;
                currentValue = string.Empty;
            }

            return options;
        }

        private string ParseCommandName(string[] args)
        {
            var commandName = args[_commandIndexPlacement];

            return commandName;
        }
    }
}
