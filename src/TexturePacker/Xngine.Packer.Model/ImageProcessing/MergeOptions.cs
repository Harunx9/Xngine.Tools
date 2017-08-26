namespace Xngine.Packer.Model.ImageProcessing
{
    public class MergeOptions
    {
        public bool Crop { get;  }
        public int MaxWidth { get; }
        public int MaxHeight { get;  }
        public int MarginX { get;  }
        public int MarginY { get; }
        public string NamePattern { get; }
        public bool SearchName { get; }

        public MergeOptions(string namePattern,
            bool crop,
            int maxWidth,
            int maxHeight,
            int marginX,
            int marginY,
            bool searchName)
        {
            NamePattern = namePattern;
            Crop = crop;
            MaxWidth = maxWidth;
            MaxHeight = maxHeight;
            MarginX = marginX;
            MarginY = marginY;
            SearchName = searchName;
        }
    }
}
