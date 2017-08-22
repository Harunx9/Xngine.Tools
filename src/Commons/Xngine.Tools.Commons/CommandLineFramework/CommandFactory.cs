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
            Type[] commands = AssemblyFinder
                .GetCurrentAssemblyWithDependencies()
                .SelectMany(x => x.GetTypes()
                    .Where(z => z.GetTypeInfo().GetCustomAttribute<CommandAttribute>() != null &&
                    z.GetTypeInfo().GetCustomAttribute<CommandAttribute>().Name == args.CommandName)).ToArray();

            if (commands.Count() > 1)
                throw new TooManyCommandsWithSameNameException(args.CommandName);

            var commandType = commands.First();
            
            var instance = Activator.CreateInstance<T>();

            foreach (var prop in instance.GetType().GetProperties())
            {
                var attribute = prop.GetCustomAttribute<CommandOptionsValueAttribute>();
                if (attribute != null)
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
                    else if(attribute.DefaultValue != null)
                        prop.SetValue(instance, Convert.ChangeType(attribute.DefaultValue, prop.PropertyType));
                    else
                        prop.SetValue(instance, Convert.ChangeType(prop.PropertyType.GetDefaultValue(), prop.PropertyType));
                }
            }
            
            return instance;
        }
    }
}
