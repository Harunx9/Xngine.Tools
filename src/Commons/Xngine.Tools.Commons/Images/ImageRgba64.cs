using ImageSharp;
using ImageSharp.PixelFormats;
using SixLabors.Primitives;
using System;
using Xngine.Tools.Commons.Exceptions;

namespace Xngine.Tools.Commons.Images
{
    public class ImageRgba64 : IImage,  IDisposable
    {
        private readonly Image<Rgba64> _image;
        public string Path { get; private set; }
        public string Name => System.IO.Path.GetFileName(Path);
        public int Width => _image.Width;
        public int Height => _image.Height;
        public bool IsEmpty => _image.Pixels.IsEmpty;
        public int PixelCount => _image.Pixels.Length;

        public ImageRgba64(string path)
        {
            _image = Image.Load<Rgba64>(path);
            Path = path;
        }

        public ImageRgba64(byte[] data)
        {
            _image = Image.Load<Rgba64>(data);
        }

        public ImageRgba64(int width, int height)
        {
            _image = new Image<Rgba64>(width, height);
        }

        public void Save(string path)
        {
            _image.Save(path);
        }

        public void DrawToImage(IImage other, int x, int y, float trnasparency = 1)
        {
            ImageRgba64 oth = CastToSelf(other);

            _image.DrawImage(oth._image, trnasparency, default(Size), new Point(x, y));
        }

        public void DrawToImage(IImage other, int x, int y, int width, int height, float trnasparency = 1.0f)
        {
            ImageRgba64 oth = CastToSelf(other);

            _image.DrawImage(oth._image, trnasparency, new Size(width, height), new Point(x, y));
        }

        public void Dispose()
        {
            _image.Dispose();
        }

        private static ImageRgba64 CastToSelf(IImage other)
        {
            var oth = other as ImageRgba64;

            if (oth == null)
                throw new TypeMismatchException();

            return oth;
        }
    }
}
