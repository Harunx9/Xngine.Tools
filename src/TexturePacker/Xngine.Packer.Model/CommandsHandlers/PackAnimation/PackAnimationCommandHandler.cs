using System.IO;
using Xngine.Packer.Model.CommandsHandlers.Exceptions;
using Xngine.Packer.Model.ImageProcessing;
using Xngine.Packer.Model.SerializableEntities;
using Xngine.Tools.Commons.CommandLineFramework;
using Xngine.Tools.Commons.CommandLineFramework.Attributes;
using Xngine.Tools.Commons.Images;
using Xngine.Tools.Commons.Time;
using Xngine.Tools.Commons.Xml;

namespace Xngine.Packer.Model.CommandsHandlers.PackAnimation
{
    [CommandHandler("packanimation")]
    public sealed class PackAnimationCommandHandler : ConsoleCommandHandler<PackAnimationCommand>
    {
        private readonly IImageMerger _merger;
        private readonly IXmlSerializer _serializer;
        private readonly ISpeitesheetPersistor _persistor;
        private readonly ITime _time;

        public PackAnimationCommandHandler(
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

        public override void Execute(PackAnimationCommand command, TextWriter @out)
        {
            var spriteSheetConfig = _merger.MergeFor<ImageRgba32>
                (command.InputDirectory,
                new MergeOptions(
                    command.InputFileParsingPattern,
                    false,
                    command.MaxWidth,
                    command.MaxWidth,
                    0, 0,
                    string.IsNullOrWhiteSpace(command.PackedName) == false));

            var validator = new SpriteSheetConfigValidator(command.InputFileParsingPattern);

            if (validator.Validate(spriteSheetConfig) == false)
                throw new AnimationFileNameNotMatchPatternException();

            var animationSheet = AnitationSpriteSheet.Create(spriteSheetConfig, command.InputFileParsingPattern);
            string sheetFileName = DetermineSheetName(command, spriteSheetConfig);

            _persistor.Save(
                _serializer.SerializeToXmlString(animationSheet),
                spriteSheetConfig.Image,
                command.OutputDirectory,
                sheetFileName,
                command.ImageFileExtension);
        }

        private string DetermineSheetName(PackAnimationCommand command, SpriteSheetConfig<ImageRgba32> spriteSheetConfig)
        {
            var name = string.IsNullOrWhiteSpace(command.PackedName) ? spriteSheetConfig.Name : command.PackedName;
            if (string.IsNullOrEmpty(name))
                name = $"Unknown{_time.Now().GetHashCode().ToString()}";
            return name;
        }
    }
}
