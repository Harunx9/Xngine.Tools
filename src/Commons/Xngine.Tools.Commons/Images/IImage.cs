using System;
using System.Collections.Generic;

namespace Xngine.Tools.Commons.Images
{
    public interface IImage
    {
        string Path { get; }
        string Name { get; }
        int Width { get; }
        int Height { get; }
        bool IsEmpty { get; }
        int PixelCount { get; }
        void Save(string path);
        void DrawToImage(IImage other, int x, int y, float trnasparency = 1.0f);
        void DrawToImage(IImage other, int x, int y, int width, int height, float trnasparency = 1.0f);
    }

    delegate IImage CreateEmptyImage(int width, int height);

    public static class EmptyImageFactory
    {
        private static readonly Dictionary<Type, CreateEmptyImage> _factories = new Dictionary<Type, CreateEmptyImage>
        {
            [typeof(ImageRgba32)] = (w, h) => new ImageRgba32(w, h),
            [typeof(ImageRgba64)] = (w, h) => new ImageRgba64(w, h),
        };

        public static TImage Create<TImage>(int width, int height) where TImage : class, IImage
        {
            var factory = _factories[typeof(TImage)];

            return factory(width, height) as TImage;
        }
    }

    delegate IImage CreateImageFromPath(string path);

    public static class ImageFromPathFactory
    {
        private static readonly Dictionary<Type, CreateImageFromPath> _factories = new Dictionary<Type, CreateImageFromPath>
        {
            [typeof(ImageRgba32)] = p => new ImageRgba32(p),
            [typeof(ImageRgba64)] = p => new ImageRgba64(p),
        };

        public static TImage Create<TImage>(string path) where TImage : class, IImage
        {
            var factory = _factories[typeof(TImage)];

            return factory(path) as TImage;
        }
    }
}
