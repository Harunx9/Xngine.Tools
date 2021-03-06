﻿using System;

namespace Xngine.Tools.Commons.CommandLineFramework.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class CommandHandlerAttribute : Attribute
    {
        public string CommandName { get; }

        public CommandHandlerAttribute(string commandName)
        {
            CommandName = commandName;
        }
    }
}
