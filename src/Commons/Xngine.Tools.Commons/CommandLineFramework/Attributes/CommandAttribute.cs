using System;

namespace Xngine.Tools.Commons.CommandLineFramework.Attributes
{
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class CommandAttribute : Attribute
    {
        public string Name { get; private set; }
        public string Alias { get; set; }
        public string HelpText { get; set; }

        public CommandAttribute(string name)
        {
            Name = name;
        }
    }

    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public sealed class CommandOptionsValueAttribute : Attribute
    {
        public string Name { get; private set; }
        public string Alias { get; set; }
        public bool Required { get; set; }
        public object DefaultValue { get; set; }
        public string HelpText { get; set; }

        public CommandOptionsValueAttribute(string name)
        {
            Name = name;
        }
    }
}
