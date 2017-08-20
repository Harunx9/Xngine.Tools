using System.Collections.Generic;
using System.Linq;
using Xngine.Tools.Commons.Images;
using Xngine.Tools.Commons.Ioc;

namespace Xngine.Packer.Model.ImageProcessing.ConfigCreator
{
    [Dependency]
    public class SameImagesWithoutCropConfigCreator : IConfigCreator
    {

        private static readonly int EMPTY_IMAGE_DIMENSION = -1;

        public bool CanCreate(IEnumerable<IImage> images, MergeOptions options)
        {
            if (images.Any() == false)
                return false;

            return IsSameImages(images);
        }

        private bool IsSameImages(IEnumerable<IImage> images)
        {
            int width = EMPTY_IMAGE_DIMENSION;
            int height = EMPTY_IMAGE_DIMENSION;

            foreach (var image in images)
            {
                if (width == EMPTY_IMAGE_DIMENSION && height == EMPTY_IMAGE_DIMENSION)
                {
                    width = image.Width;
                    height = image.Height;
                }
                else
                {
                    if (image.Height != height && image.Width != width)
                        return false;
                }
            }

            return true;
        }

        public SpriteSheetConfig Create(IEnumerable<IImage> images, MergeOptions options)
        {
            int sumWidth = images.Sum(x => x.Width);
            int rowCount = 1;
            while (sumWidth > options.MaxWidth)
            {
                sumWidth /= 2;
                rowCount++;
            }

            int sheetWidth = sumWidth;
            int sheetHeight = rowCount * images.First().Height;

            int currentY = 0;
            int currentX = 0;
            var desctiptors = new List<ImageDescriptor>();

            foreach (var image in images)
            {
                if (currentX + image.Width > sheetWidth)
                {
                    currentY += image.Height;
                    currentX = 0;
                }

                desctiptors.Add(new ImageDescriptor(image.Name, currentX, currentY, image.Width, image.Height));
                currentX += image.Width;
            }

            return new SpriteSheetConfig(options.MarginX, options.MarginY, sheetWidth, sheetHeight, desctiptors);
        }
    }
}
