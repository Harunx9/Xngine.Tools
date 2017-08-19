using FluentAssertions;
using System;
using System.IO;
using Xngine.Packer.Model.ImageProcessing;
using Xngine.Packer.Model.ImageProcessing.ConfigCreator;
using Xngine.Tools.Tests.BaseFramework;
using Xunit;
using Images = Xngine.Tools.Commons.Images;

namespace Xngine.Tools.Tests.Image.Merging
{
    public class on_image_merge_when_input_dir_not_exist : ImageMergeBase
    {
        private Exception result;
        private MergeOptions options;

        protected override void Arrange()
        {
            options = new MergeOptions(false, 256, 256, 0, 0);
            merger = new ImageMerger(new MergeWithConfigurationAlgorithm(),
                new IConfigCreator[] { new SameImagesWithoutCropConfigCreator(), new DifferentDimeansionImageWithoutCropConfigCreator() });
        }

        protected override void Act()
        {
            result = Record.Exception(() => merger.MergeFor<Images.ImageRgba32>("./TestData/Imagesddd", options));
        }

        [Assert]
        public void DirectoryNotFoundException_shoudl_be_thrown()
           => result.Should().BeOfType<DirectoryNotFoundException>();
    }
}
