using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Xngine.Tools.Commons.Ioc
{
    public static class AssemblyFinder
    {
        public static Assembly[] GetCurrentAssemblyWithDependencies()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var dllFiles = Directory.EnumerateFiles(currentDirectory, "*.dll");

            return dllFiles
                .Select(x => Assembly
                    .Load(new AssemblyName(Path.GetFileNameWithoutExtension(x))))
                .ToArray();
        }


        public static Assembly[] GetCurrentAssemblyWithDependenciesWithPattern(string pattern)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var dllFiles = Directory.EnumerateFiles(currentDirectory, pattern);

            return dllFiles
                .Select(x => Assembly
                    .Load(new AssemblyName(Path.GetFileNameWithoutExtension(x))))
                .ToArray();
        }
    }
}
