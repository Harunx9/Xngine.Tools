using System.Collections.Generic;
using System.Linq;
using Xngine.Tools.Commons.Images;

namespace Xngine.Packer.Model.ImageProcessing
{
    public class SpriteSheetConfig
    {
        public int OffsetX { get; }
        public int OffsetY { get; }
        public int Width { get; }
        public int Height { get; }
        public IEnumerable<ImageDescriptor> Descriptors { get; }

        public SpriteSheetConfig(int offsetX, int offsetY, int width, int height,
            IEnumerable<ImageDescriptor> descriptors)
        {
            OffsetX = offsetX;
            OffsetY = offsetY;
            Width = width;
            Height = height;
            Descriptors = descriptors;
        }

        public ImageDescriptor GetDescriptorForImage<TImage>(TImage image) where TImage : class, IImage
        {
            return Descriptors.First(x => x.Name == image.Name);
        }
    }

    public class SpriteSheetConfig<TImage> : SpriteSheetConfig
    {
        public TImage Image { get; }

        public SpriteSheetConfig(int offsetX, int offsetY, int width, int height,
            IEnumerable<ImageDescriptor> descriptors, TImage image) :
            base(offsetX, offsetY, width, height, descriptors)
        {
            Image = image;
        }

        public SpriteSheetConfig(SpriteSheetConfig other, TImage image) :
            base(other.OffsetX, other.OffsetY, other.Width, other.Height, other.Descriptors.ToArray())
        {
            Image = image;
        }
    }

    public class ImageDescriptor
    {
        public string Name { get; }
        public int X { get; }
        public int Y { get; }
        public int Width { get; }
        public int Height { get; }

        public ImageDescriptor(string name, int x, int y, int width, int height)
        {
            Name = name;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }

    public interface IConfigCreator
    {
        bool CanCreate(IEnumerable<IImage> images, MergeOptions options);
        SpriteSheetConfig Create(IEnumerable<IImage> images, MergeOptions options);
    }
}
