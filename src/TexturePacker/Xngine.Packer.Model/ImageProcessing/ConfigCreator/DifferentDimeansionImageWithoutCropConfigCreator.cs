using System;
using System.Collections.Generic;
using Xngine.Tools.Commons.Images;

namespace Xngine.Packer.Model.ImageProcessing.ConfigCreator
{
    public class DifferentDimeansionImageWithoutCropConfigCreator : IConfigCreator
    {
        public bool CanCreate(IEnumerable<IImage> images, MergeOptions options)
        {
            throw new NotImplementedException();
        }

        public SpriteSheetConfig Create(IEnumerable<IImage> images, MergeOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
