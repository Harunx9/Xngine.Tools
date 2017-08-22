using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Xngine.Tools.Commons.CommandLineFramework
{
    public static class TypeCheckExtensions
    {
        public static bool IsDefault<T>(this T instance)
        {
            return instance.Equals(default(T));
        }
    }

    public static class TypeExtensions
    {
        public static object GetDefaultValue(this Type type)
        {
            if (type.GetTypeInfo().IsValueType)
                return Activator.CreateInstance(type);
            return null;
        }
    }
}
