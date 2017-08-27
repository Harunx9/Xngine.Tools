using System;
using System.Collections.Generic;
using Xngine.Tools.Commons.Images;
using Xngine.Tools.Commons.Ioc;

namespace Xngine.Packer.Model.ImageProcessing.ConfigCreator
{
    [Dependency]
    internal class DifferentDimeansionImageWithoutCropConfigCreator : IConfigCreator
    {
        public bool CanCreate(IEnumerable<IImage> images, MergeOptions options)
        {
            return false;
        }

        public SpriteSheetConfig Create(IEnumerable<IImage> images, MergeOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
