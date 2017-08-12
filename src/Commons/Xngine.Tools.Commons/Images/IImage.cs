using System;
using System.Collections.Generic;
using System.Text;

namespace Xngine.Tools.Commons.Images
{
    public interface IImage
    {
        string Path { get; }
        int Width { get; }
        int Height { get; }
        bool IsEmpty { get; }
        int PixelCount { get; }
        void Save(string path);
    }

    public interface IImage<TImage> : IImage
        where TImage : IImage
    {
        void DrawToImage(TImage other, int x, int y, float trnasparency = 1.0f);
        void DrawToImage(TImage other, int x, int y, int width, int height, float trnasparency = 1.0f);
    }
}
