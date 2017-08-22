using System.IO;
using System.Text;
using Xngine.Tools.Commons.CommandLineFramework.Attributes;

namespace Xngine.Tools.Commons.CommandLineFramework.DefaultCommands
{
    [CommandHandler("help")]
    public class HelpCommandHandler : ConsoleCommandHandler<HelpCommand>
    {
        private readonly IHelpGenerator _helpGenerator;

        public HelpCommandHandler(IHelpGenerator helpGenerator)
        {
            _helpGenerator = helpGenerator;
        }

        public override void Execute(HelpCommand command, TextWriter @out)
        {
            StringBuilder helpText;
            if (string.IsNullOrWhiteSpace(command.CommandName) == false)
            {
                helpText = _helpGenerator.GenerateForCommand(command.CommandName);
            }
            else
            {
                helpText = _helpGenerator.GenerateForProgram();
            }

            if (string.IsNullOrWhiteSpace(command.ErrorMessage) == false)
            {
                helpText.AppendLine("Error message");
                helpText.AppendLine(command.ErrorMessage);
            }

            @out.Write(helpText);
        }
    }
}
