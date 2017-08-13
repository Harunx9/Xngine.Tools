using System.Runtime.CompilerServices;
using Xunit;

namespace Xngine.Tools.Tests.BaseFramework
{
    public class AssertAttribute : FactAttribute
    {
        public AssertAttribute(
            string separatorReplacement = " ",
            string separator = "_",
            [CallerMemberName] string methodName = "")
        {
            DisplayName = methodName.Replace(separator, separatorReplacement);
        }
    }
}
