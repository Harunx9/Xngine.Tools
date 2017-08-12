using ImageSharp;
using ImageSharp.PixelFormats;
using SixLabors.Primitives;
using System;

namespace Xngine.Tools.Commons.Images
{
    public class ImageRgba64 : IImage<ImageRgba64>,  IDisposable
    {
        private readonly Image<Rgba64> _image;
        public string Path { get; private set; }
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

        public void DrawToImage(ImageRgba64 other, int x, int y, float trnasparency = 1)
        {
            _image.DrawImage(other._image, trnasparency, default(Size), new Point(x, y));
        }

        public void DrawToImage(ImageRgba64 other, int x, int y, int width, int height, float trnasparency = 1.0f)
        {
            _image.DrawImage(other._image, trnasparency, new Size(width, height), new Point(x, y));
        }

        public void Dispose()
        {
            _image.Dispose();
        }
    }
}
