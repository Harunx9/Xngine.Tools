namespace Xngine.Packer.Model.ImageProcessing
{
    public class MergeOptions
    {
        public bool Crop { get; private set; }
        public int MaxWidth { get; private set; }
        public int MaxHeight { get; private set; }
        public int MarginX { get; private set; }
        public int MarginY { get; private set; }

        public MergeOptions(bool crop, int maxWidth, int maxHeight, int marginX, int marginY)
        {
            Crop = crop;
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
            MarginX = marginX;
            MarginY = marginY;
        }
    }
}
