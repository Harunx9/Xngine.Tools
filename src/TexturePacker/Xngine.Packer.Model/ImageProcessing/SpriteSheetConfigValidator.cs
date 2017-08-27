using System.Text.RegularExpressions;
using Xngine.Tools.Commons.Ioc;

namespace Xngine.Packer.Model.ImageProcessing
{
    internal sealed class SpriteSheetConfigValidator
    {
        private readonly string _pattern;

        public SpriteSheetConfigValidator(string pattern)
        {
            _pattern = pattern;
        }

        public bool Validate<T>(SpriteSheetConfig<T> spriteSheetConfig)
        {
            foreach (var descriptor in spriteSheetConfig.Descriptors)
            {
                if (ValidateName(descriptor.Name) == false)
                    return false;
            }
            return true;
        }

        private bool ValidateName(string name)
        {
            return Regex.IsMatch(name, _pattern);
        }

        public bool Validate(SpriteSheetConfig spriteSheetConfig)
        {
            foreach (var descriptor in spriteSheetConfig.Descriptors)
            {
                if (ValidateName(descriptor.Name) == false)
                    return false;
            }
            return true;
        }
    }
}
