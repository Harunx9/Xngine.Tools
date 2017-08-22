using System;
using System.IO;
using Xngine.Tools.Commons.CommandLineFramework.DefaultCommands;

namespace Xngine.Tools.Commons.CommandLineFramework
{
    public sealed class CommandLineApplication
    {
        private readonly ICommandResolver _resolver;
        private readonly TextWriter _out;

        public CommandLineApplication(ICommandResolver resolver, TextWriter @out)
        {
            _resolver = resolver;
            _out = @out;
        }

        public void Run(string[] args)
        {
            var parser = new CommandLineArgsParser("--", new[] { '=', ':' }, 0);
            try
            {
                var parsedArgs = parser.Parse(args);
                var handler = _resolver.ResolveCommandHandler(parsedArgs);
                if (handler != null)
                {
                    handler.ExecuteFromParsedArgs(parsedArgs, _out);
                }
            }
            catch (Exception e)
            {
                var help = _resolver.ResolveCommandHandler<HelpCommandHandler>("help");
                help.Execute(new HelpCommand { ErrorMessage = e.Message }, _out);
            }
        }
    }
}
