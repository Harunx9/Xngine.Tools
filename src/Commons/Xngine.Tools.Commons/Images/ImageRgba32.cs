using ImageSharp;
using ImageSharp.PixelFormats;
using SixLabors.Primitives;
using System;

namespace Xngine.Tools.Commons.Images
{
    public class ImageRgba32 : IImage<ImageRgba32>,  IDisposable
    {
        private readonly Image<Rgba32> _image;
        public string Path { get; private set; }
        public int Width => _image.Width;
        public int Height => _image.Height;
        public bool IsEmpty => _image.Pixels.IsEmpty;
        public int PixelCount => _image.Pixels.Length;

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

        public void DrawToImage(ImageRgba32 other, int x, int y, float trnasparency = 1)
        {
            _image.DrawImage(other._image, trnasparency, default(Size), new Point(x, y));
        }

        public void DrawToImage(ImageRgba32 other, int x, int y, int width, int height, float trnasparency = 1.0f)
        {
            _image.DrawImage(other._image, trnasparency, new Size(width, height), new Point(x, y));
        }

        public void Dispose()
        {
            _image.Dispose();
        }
    }
}
