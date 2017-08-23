using System;
using System.IO;
using Xngine.Tools.Commons.CommandLineFramework;
using Xngine.Tools.Commons.CommandLineFramework.Attributes;

namespace Xngine.Tools.Tests.CommandlineFramework
{
    [CommandHandler("test")]
    public class TestCommandHandler : ConsoleCommandHandler<TestCommand>
    {
        public override void Execute(TestCommand command, TextWriter @out)
        {
            @out.WriteLine("Testing");
        }
    }
}
