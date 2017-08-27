using System.IO;
using Xngine.Packer.Model.CommandsHandlers.Exceptions;
using Xngine.Packer.Model.ImageProcessing;
using Xngine.Packer.Model.SerializableEntities;
using Xngine.Tools.Commons.CommandLineFramework;
using Xngine.Tools.Commons.CommandLineFramework.Attributes;
using Xngine.Tools.Commons.Images;
using Xngine.Tools.Commons.Time;
using Xngine.Tools.Commons.Xml;

namespace Xngine.Packer.Model.CommandsHandlers.PackSpritesheet
{
    [CommandHandler("packspritesheet")]
    public sealed class PackSpritesheetCommandHandler : ConsoleCommandHandler<PackSpritesheetCommand>
    {
        private readonly IImageMerger _merger;
        private readonly IXmlSerializer _serializer;
        private readonly ISpeitesheetPersistor _persistor;
        private readonly ITime _time;

        public PackSpritesheetCommandHandler(
            IImageMerger merger,
            IXmlSerializer serializer,
            ISpeitesheetPersistor persistor,
            ITime time)
        {
            _merger = merger;
            _serializer = serializer;
            _persistor = persistor;
            _time = time;
        }

        public override void Execute(PackSpritesheetCommand command, TextWriter @out)
        {
            var spriteSheetConfig = _merger.MergeFor<ImageRgba32>
                (command.InputDirectory,
                new MergeOptions(
                    string.Empty,
                    false,
                    command.MaxWidth,
                    command.MaxWidth,
                    0, 0,
                    string.IsNullOrWhiteSpace(command.PackedName) == false));

            var animationSheet = SpriteSheet.Create(spriteSheetConfig);
            string sheetFileName = DetermineSheetName(command.PackedName);

            _persistor.Save(
                _serializer.SerializeToXmlString(animationSheet),
                spriteSheetConfig.Image,
                command.OutputDirectory,
                sheetFileName,
                command.ImageFileExtension);
        }

        private string DetermineSheetName(string name)
        {
            return string.IsNullOrWhiteSpace(name) ?
                $"Unknown{_time.Now().GetHashCode().ToString()}" : name;
        }
    }
}
