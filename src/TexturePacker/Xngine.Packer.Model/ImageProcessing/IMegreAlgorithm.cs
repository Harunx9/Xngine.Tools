﻿using System.Collections.Generic;
using Xngine.Tools.Commons.Images;
using Xngine.Tools.Commons.Ioc;

namespace Xngine.Packer.Model.ImageProcessing
{
    public interface IMegreWithConfigAlgorithm
    {
        TImage Merge<TImage>(SpriteSheetConfig config, IEnumerable<TImage> images) where TImage : class, IImage;
    }

    [Dependency]
    internal sealed class MergeWithConfigurationAlgorithm : IMegreWithConfigAlgorithm
    {
        public TImage Merge<TImage>(SpriteSheetConfig config, IEnumerable<TImage> images) where TImage : class, IImage
        {
            var img = EmptyImageFactory.Create<TImage>(config.Width, config.Height);

            foreach (var image in images)
            {
                var descriptor = config.GetDescriptorForImage(image);
                if (descriptor == null) continue;

                img.DrawToImage(image, descriptor.X, descriptor.Y);
            }

            return img;
        }
    }
}
