using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xngine.Tools.Commons.Images;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.Image.ImageSorting
{
    public class on_desc_image_collection_sort : ImageSortingBase
    {
        private IEnumerable<IImage> result;

        protected override void Arrange()
        {
            imageList = new List<ImageRgba32>();
            imageList.Add(new ImageRgba32(MeticsImagePath));
            imageList.Add(new ImageRgba32(TilesImagePath));

            sorter = new ImageSorter();
        }

        protected override void Act()
            => result = sorter.SortBy(x => x.PixelCount, imageList, SortDir.DESC);

        [Assert]
        public void tiles_image_should_be_first()
            => result.First().Path.Should().Be(TilesImagePath);

        [Assert]
        public void metrics_image_should_be_second()
            => result.Last().Path.Should().Be(MeticsImagePath);
    }
}
