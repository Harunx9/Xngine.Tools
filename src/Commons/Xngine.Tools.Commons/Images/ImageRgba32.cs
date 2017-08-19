using ImageSharp;
using SixLabors.Primitives;
using System;
using Xngine.Tools.Commons.Exceptions;

namespace Xngine.Tools.Commons.Images
{
    public class ImageRgba32 : IImage, IDisposable
    {
        private readonly Image<Rgba32> _image;
        public string Path { get; private set; }
        public int Width => _image.Width;
        public int Height => _image.Height;
        public bool IsEmpty => _image.Pixels.IsEmpty;
        public int PixelCount => _image.Pixels.Length;
        public string Name => System.IO.Path.GetFileName(Path);

        public ImageRgba32(string path)
        {
            _image = Image.Load(path);
            Path = path;
        }

        public ImageRgba32(byte[] data)
        {
            _image = Image.Load(data);
        }

        public ImageRgba32(int width, int height)
        {
            _image = new Image<Rgba32>(width, height);
        }

        public void Save(string path)
        {
            _image.Save(path);
        }

        public void DrawToImage(IImage other, int x, int y, float trnasparency = 1)
        {
            ImageRgba32 oth = CastToSelf(other);

            _image.DrawImage(oth._image, trnasparency, default(Size), new Point(x, y));
        }


        public void DrawToImage(IImage other, int x, int y, int width, int height, float trnasparency = 1.0f)
        {
            ImageRgba32 oth = CastToSelf(other);

            _image.DrawImage(oth._image, trnasparency, new Size(width, height), new Point(x, y));
        }

        public void Dispose()
        {
            _image.Dispose();
        }

        private static ImageRgba32 CastToSelf(IImage other)
        {
            var oth = other as ImageRgba32;

            if (oth == null)
                throw new TypeMismatchException();

            return oth;
        }
    }
}
