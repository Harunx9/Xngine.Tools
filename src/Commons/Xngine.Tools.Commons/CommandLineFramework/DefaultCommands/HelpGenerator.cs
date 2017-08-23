using System.Linq;
using System.Reflection;
using System.Text;
using Xngine.Tools.Commons.CommandLineFramework.Attributes;
using Xngine.Tools.Commons.CommandLineFramework.Exceptions;
using Xngine.Tools.Commons.Ioc;

namespace Xngine.Tools.Commons.CommandLineFramework.DefaultCommands
{
    public interface IHelpGenerator
    {
        StringBuilder GenerateForProgram();
        StringBuilder GenerateForCommand(string commandName);
    }
    
    [Dependency]
    public class HelpGenerator : IHelpGenerator
    {
        public StringBuilder GenerateForProgram()
        {
            var commands = AssemblyFinder.GetCurrentAssemblyWithDependencies()
                .SelectMany(x => x.GetTypes()
                .Where(t => t.GetTypeInfo().GetCustomAttribute<CommandAttribute>() != null));

            var helpBuilder = new StringBuilder();
            helpBuilder.AppendLine($"Program usage command [<opts>]");
            helpBuilder.AppendLine($"Commands list:");

            foreach (var command in commands)
            {
                var commandAtt = command.GetTypeInfo().GetCustomAttribute<CommandAttribute>();

                helpBuilder.AppendLine($"    {commandAtt.Name} or {commandAtt.Alias} {commandAtt.HelpText}");
            }

            return helpBuilder;
        }

        public StringBuilder GenerateForCommand(string commandName)
        {
            var commands = AssemblyFinder.GetCurrentAssemblyWithDependencies()
                .SelectMany(x => x.GetTypes()
                .Where(t => t.GetTypeInfo().GetCustomAttribute<CommandAttribute>() != null &&
                (t.GetTypeInfo().GetCustomAttribute<CommandAttribute>().Name == commandName || 
                t.GetTypeInfo().GetCustomAttribute<CommandAttribute>().Alias == commandName)));

            if (commands.Any() == false)
                throw new CommandNotFoundException(commandName);

            if (commands.Count() > 1)
                throw new TooManyCommandsWithSameNameException(commandName);

            var helpBuilder = new StringBuilder();

            var command = commands.First();
            var commandAtt = command.GetTypeInfo().GetCustomAttribute<CommandAttribute>();

            helpBuilder = new StringBuilder();
            helpBuilder.AppendLine(commandAtt.HelpText);
            helpBuilder.AppendLine($"Command usage {commandAtt.Name} or {commandAtt.Alias} [<opts>]");
            helpBuilder.AppendLine($"Option list:");

            var optionValuesProps = command.GetProperties()
                .Where(x => x.GetCustomAttribute<CommandOptionsValueAttribute>() != null);

            foreach (var prop in optionValuesProps)
            {
                var attribute = prop.GetCustomAttribute<CommandOptionsValueAttribute>();
                var required = attribute.Required ? "| Required |" : "";

                helpBuilder.AppendLine($"    --{attribute.Name} | --{attribute.Alias} {required} {attribute.HelpText}");
            }

            return helpBuilder;
        }
        
    }
}
