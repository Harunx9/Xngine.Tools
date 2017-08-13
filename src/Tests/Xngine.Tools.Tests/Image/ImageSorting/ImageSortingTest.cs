using System.Collections.Generic;
using System.Linq;
using Xngine.Tools.Commons.Images;

namespace Xngine.Tools.Tests.Image.ImageSorting
{
    public abstract class ImageSortingBase : ImageBase
    {
        protected IImageSorter sorter;
        protected List<ImageRgba32> imageList;
    }
}
