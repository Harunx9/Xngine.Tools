using FluentAssertions;
using Xngine.Tools.Commons.Images;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.Image.ImageRgb64
{
    public class on_image64_load_from_file : ImageBase
    {
        private ImageRgba64 image;

        protected override void Arrange() { }

        protected override void Act()
        {
            image = new ImageRgba64(MeticsImagePath);
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
