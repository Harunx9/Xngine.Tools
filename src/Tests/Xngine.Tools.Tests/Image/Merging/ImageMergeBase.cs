using System.IO;
using Xngine.Packer.Model.ImageProcessing;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.Image.Merging
{
    public abstract class ImageMergeBase : AAATest
    {
        protected IImageMerger merger;
        protected string TilesImagePath => Path.Combine(Directory.GetCurrentDirectory(), "TestData/Images/tiles.png");
        protected string MeticsImagePath => Path.Combine(Directory.GetCurrentDirectory(), "TestData/Images/metrics.png");
    }
}
