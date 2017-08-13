using System.IO;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.Image
{
    public abstract class ImageBase : AAATest
    {
        protected string TilesImagePath => Path.Combine(Directory.GetCurrentDirectory(), "TestData/Images/tiles.png");
        protected string MeticsImagePath => Path.Combine(Directory.GetCurrentDirectory(), "TestData/Images/metrics.png");
    }
}
