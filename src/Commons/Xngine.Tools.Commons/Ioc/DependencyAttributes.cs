using System;

namespace Xngine.Tools.Commons.Ioc
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class DependencyAttribute : Attribute{}

    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public sealed class NamedDependencyAttribute : Attribute
    {
        public string Name { get; }
        public NamedDependencyAttribute(string name)
        {
            Name = name;
        }
    }
}
