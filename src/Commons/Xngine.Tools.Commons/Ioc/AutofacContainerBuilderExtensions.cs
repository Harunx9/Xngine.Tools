using Autofac;
using System;
using System.Linq;
using System.Reflection;

namespace Xngine.Tools.Commons.Ioc
{
    public static class AutofacContainerBuilderExtensions
    {
        public static void RegisterDependencies(this ContainerBuilder builder, Assembly[] assembiles)
        {
            foreach (var assembly in assembiles)
            {
                Type[] typesToRegiser = assembly
                    .GetTypes()
                    .Where(x => x.GetTypeInfo().GetCustomAttribute<DependencyAttribute>() != null)
                    .ToArray();

                foreach (var typeToRegister in typesToRegiser)
                {
                    var dependecyAttribute = typeToRegister.GetTypeInfo().GetCustomAttribute<DependencyAttribute>();
                    builder.RegisterType(typeToRegister).AsImplementedInterfaces();
                }
            }
        }

        public static void RegisterNamedDependencies(this ContainerBuilder builder, Assembly[] assembiles)
        {
            foreach (var assembly in assembiles)
            {
                Type[] typesToRegiser = assembly
                    .GetTypes()
                    .Where(x => x.GetTypeInfo().GetCustomAttribute<NamedDependencyAttribute>() != null)
                    .ToArray();

                foreach (var typeToRegister in typesToRegiser)
                {
                    var dependecyAttribute = typeToRegister.GetTypeInfo().GetCustomAttribute<NamedDependencyAttribute>();
                    builder.RegisterType(typeToRegister).Named(dependecyAttribute.Name, typeToRegister);
                }
            }
        }
    }
}
