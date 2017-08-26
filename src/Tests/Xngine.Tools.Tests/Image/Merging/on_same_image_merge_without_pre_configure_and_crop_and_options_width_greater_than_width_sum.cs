using FluentAssertions;
using System.Linq;
using Xngine.Packer.Model.ImageProcessing;
using Xngine.Packer.Model.ImageProcessing.ConfigCreator;
using Xngine.Tools.Tests.BaseFramework;
using Images = Xngine.Tools.Commons.Images;

namespace Xngine.Tools.Tests.Image.Merging
{
    public class on_same_image_merge_without_pre_configure_and_crop_and_options_width_greater_than_width_sum : ImageMergeBase
    {
        private MergeOptions options;
        private SpriteSheetConfig<Images.ImageRgba32> result;

        protected override void Arrange()
        {
            options = new MergeOptions(FileNameParsePattern, false, 64, 0, 0, 0, true);
            merger = new ImageMerger(new MergeWithConfigurationAlgorithm(),
              new IConfigCreator[] { new SameImagesWithoutCropConfigCreator(), new DifferentDimeansionImageWithoutCropConfigCreator() });
        }

        protected override void Act()
        {
            result = merger.MergeFor<Images.ImageRgba32>("./TestData/Images/Same", options);
        }

        [Assert]
        public void configurtion_result_should_not_be_null()
            => result.Should().NotBeNull();

        [Assert]
        public void configurtion_result_name_should_be_Untitled()
          => result.Name.Should().Be("Untitled");

        [Assert]
        public void configurtion_result_descriptors_should_have_4_elements()
           => result.Descriptors.Should().HaveCount(4);

        [Assert]
        public void configurtion_result_image_width_should_have_64px()
           => result.Width.Should().Be(64);

        [Assert]
        public void configurtion_result_image_height_shoudl_have_64px()
           => result.Height.Should().Be(64);

        [Assert]
        public void configurtion_result_merged_image_shoud_have_128_x_32_dimension()
        {
            result.Image.Width.Should().Be(64);
            result.Image.Height.Should().Be(64);
        }

        [Assert]
        public void configurtion_result_first_descriptor_should_have_correct_valuesl()
        {
            var desc = result.Descriptors.ElementAt(0);

            desc.Name.Should().Be("Untitled_Fall_0");
            desc.X.Should().Be(0);
            desc.Y.Should().Be(0);
            desc.Width.Should().Be(32);
            desc.Height.Should().Be(32);
        }

        [Assert]
        public void configurtion_result_second_descriptor_should_have_correct_valuesl()
        {
            var desc = result.Descriptors.ElementAt(1);

            desc.Name.Should().Be("Untitled_Fall_1");
            desc.X.Should().Be(32);
            desc.Y.Should().Be(0);
            desc.Width.Should().Be(32);
            desc.Height.Should().Be(32);
        }

        [Assert]
        public void configurtion_result_third_descriptor_should_have_correct_valuesl()
        {
            var desc = result.Descriptors.ElementAt(2);

            desc.Name.Should().Be("Untitled_Fall_2");
            desc.X.Should().Be(0);
            desc.Y.Should().Be(32);
            desc.Width.Should().Be(32);
            desc.Height.Should().Be(32);
        }

        [Assert]
        public void configurtion_result_fourth_descriptor_should_have_correct_valuesl()
        {
            var desc = result.Descriptors.ElementAt(3);

            desc.Name.Should().Be("Untitled_Fall_3");
            desc.X.Should().Be(32);
            desc.Y.Should().Be(32);
            desc.Width.Should().Be(32);
            desc.Height.Should().Be(32);
        }
    }
}
