using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xngine.Tools.Commons.Exceptions;
using Xngine.Tools.Commons.Images;
using Xngine.Tools.Commons.Ioc;

namespace Xngine.Packer.Model.ImageProcessing
{
    public interface IImageMerger
    {
        SpriteSheetConfig<TImage> MergeFor<TImage>(string inputPath, MergeOptions options) where TImage : class, IImage;
        SpriteSheetConfig<TImage> MergeFor<TImage>(SpriteSheetConfig sheetConfig, string inputPath) where TImage : class, IImage;
    }

    [Dependency]
    internal sealed class ImageMerger : IImageMerger
    {
        private readonly IMegreWithConfigAlgorithm _configMergeAlgorithm;
        private readonly IEnumerable<IConfigCreator> _configCreators;

        public ImageMerger(
            IMegreWithConfigAlgorithm configMergeAlgorithm,
            IEnumerable<IConfigCreator> configCreators)
        {
            _configMergeAlgorithm = configMergeAlgorithm;
            _configCreators = configCreators;
        }

        public SpriteSheetConfig<TImage> MergeFor<TImage>(string inputPath, MergeOptions options) where TImage : class, IImage
        {
            if (Directory.Exists(inputPath) == false)
                throw new DirectoryNotFoundException();

            var filePaths = Directory.EnumerateFiles(inputPath);

            if (filePaths.Any() == false)
                throw new FolderIsEmptyException();

            var images = filePaths.Select(x => ImageFromPathFactory.Create<TImage>(x)).ToArray();

            var creator = _configCreators.FirstOrDefault(x => x.CanCreate(images, options));

            var sheetConfig = creator.Create(images, options);

            var mergedImage = _configMergeAlgorithm.Merge(sheetConfig, images);

            return new SpriteSheetConfig<TImage>(sheetConfig, mergedImage);
        }

        public SpriteSheetConfig<TImage> MergeFor<TImage>(SpriteSheetConfig sheetConfig, string inputPath) where TImage : class, IImage
        {
            throw new NotImplementedException();
        }
    }
}
