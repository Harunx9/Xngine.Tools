using FluentAssertions;
using Xngine.Tools.Commons.Images;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.Image.ImageRgb32
{
    public class on_image32_load_from_file : ImageBase
    {
        private ImageRgba32 image;

        protected override void Arrange(){}

        protected override void Act()
        {
            image = new ImageRgba32(TilesImagePath);
        }

        [Assert]
        public void loaded_image_should_not_be_null() 
            => image.Should().NotBeNull();

        [Assert]
        public void loaded_image_should_not_be_empty()
            => image.IsEmpty.Should().BeFalse();

        [Assert]
        public void loaded_image_should_have_pixels_greater_than_0()
            => image.PixelCount.Should().BeGreaterThan(0);
    }
}
