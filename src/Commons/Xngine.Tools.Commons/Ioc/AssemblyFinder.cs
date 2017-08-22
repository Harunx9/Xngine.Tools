using System.IO;
using System.Linq;
using System.Reflection;

namespace Xngine.Tools.Commons.Ioc
{
    public static class AssemblyFinder
    {
        public static Assembly[] GetCurrentAssemblyWithDependencies()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var dllFiles = Directory.EnumerateFiles(currentDirectory, "*.dll", SearchOption.AllDirectories)
                .Select(x => Path.GetFileNameWithoutExtension(x))
                .Distinct();

            return dllFiles
                .Select(x => Assembly
                    .Load(new AssemblyName(x)))
                .ToArray();
        }


        public static Assembly[] GetCurrentAssemblyWithDependenciesWithPattern(string pattern)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var dllFiles = Directory.EnumerateFiles(currentDirectory, pattern, SearchOption.AllDirectories)
                .Select(x => Path.GetFileNameWithoutExtension(x))
                .Distinct();

            return dllFiles
                .Select(x => Assembly
                    .Load(new AssemblyName(x)))
                .ToArray();
        }
    }
}
