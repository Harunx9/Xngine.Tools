using System;
using System.Linq;
using System.Reflection;
using Xngine.Tools.Commons.CommandLineFramework.Attributes;
using Xngine.Tools.Commons.CommandLineFramework.Exceptions;
using Xngine.Tools.Commons.Ioc;

namespace Xngine.Tools.Commons.CommandLineFramework
{
    public static class CommandFactory
    {
        public static T Create<T>(CommandLineArgs args) where T : class, new()
        {
            Type[] commands = FindCommand(args);

            if (commands.Count() > 1)
                throw new TooManyCommandsWithSameNameException(args.CommandName);

            var commandType = commands.First();

            var instance = Activator.CreateInstance<T>();

            foreach (var prop in instance.GetType().GetProperties())
            {
                var attribute = prop.GetCustomAttribute<CommandOptionsValueAttribute>();
                if (attribute != null)
                {
                    SetPropertyValue(args, instance, prop, attribute);
                }
            }

            return instance;
        }

        private static void SetPropertyValue<T>(CommandLineArgs args, T instance, PropertyInfo prop, CommandOptionsValueAttribute attribute) where T : class, new()
        {
            var arg = args
                    .CommandOptionsValues
                    .FirstOrDefault(x =>
                        x.Key == attribute.Name ||
                        x.Key == attribute.Alias);

            if (arg.IsDefault() && attribute.Required)
                throw new RequiredOptionNotFoundException(attribute.Name);

            if (arg.IsDefault() == false)
                prop.SetValue(instance, Convert.ChangeType(arg.Value, prop.PropertyType));
            else if (attribute.DefaultValue != null)
                prop.SetValue(instance, Convert.ChangeType(attribute.DefaultValue, prop.PropertyType));
            else
                prop.SetValue(instance, Convert.ChangeType(prop.PropertyType.GetDefaultValue(), prop.PropertyType));
        }

        private static Type[] FindCommand(CommandLineArgs args)
        {
            return AssemblyFinder
                   .GetCurrentAssemblyWithDependencies()
                   .SelectMany(x => x.GetTypes()
                       .Where(z => z.GetTypeInfo().GetCustomAttribute<CommandAttribute>() != null &&
                       (z.GetTypeInfo().GetCustomAttribute<CommandAttribute>().Name == args.CommandName ||
                        z.GetTypeInfo().GetCustomAttribute<CommandAttribute>().Alias == args.CommandName
                       ))).ToArray();
        }
    }
}
