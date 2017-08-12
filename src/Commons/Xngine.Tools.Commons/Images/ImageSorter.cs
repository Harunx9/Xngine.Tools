using System;
using System.Collections.Generic;
using System.Linq;

namespace Xngine.Tools.Commons.Images
{
    public enum SortDir
    {
        ASC,
        DESC
    }

    public interface IImageSorter
    {
        IEnumerable<IImage> SortBy<TKey>(Func<IImage, TKey> sortProperty, IEnumerable<IImage> collectionToSort, SortDir dir);
    }

    public class ImageSorter : IImageSorter
    {
        public IEnumerable<IImage> SortBy<TKey>(Func<IImage, TKey> sortProperty, IEnumerable<IImage> collectionToSort, SortDir dir)
        {
            switch (dir)
            {
                case SortDir.ASC:
                    return collectionToSort.OrderBy(sortProperty).ToArray();
                case SortDir.DESC:
                    return collectionToSort.OrderByDescending(sortProperty).ToArray();
            }
            return collectionToSort.ToArray();
        }
    }
}
