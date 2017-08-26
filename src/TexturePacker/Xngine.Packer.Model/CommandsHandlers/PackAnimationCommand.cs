using Xngine.Tools.Commons.CommandLineFramework.Attributes;

namespace Xngine.Packer.Model.CommandsHandlers
{
    [Command("packanimation", Alias = "pa", HelpText = "Pack texture from input dir ")]
    public class PackAnimationCommand
    {
        [CommandOptionsValue("input",
            Alias = "in",
            Required = true,
            HelpText = "Input images directory")]
        public string InputDirectory { get; set; }

        [CommandOptionsValue("output",
            Alias = "out",
            Required = true,
            HelpText = "Input output directory")]
        public string OutputDirectory { get; set; }

        [CommandOptionsValue("pattern",
            Alias = "p",
            HelpText = "Regexp pattern for automatic nameing default is sheetname_animationname_framenumber",
            DefaultValue = @"(?<sheetname>[A-Za-z]+)_(?<animationname>[A-Za-z]+)_(?<framenumber>[0-9]+)")]
        public string InputFileParsingPattern { get; set; }

        [CommandOptionsValue("name", 
            Alias ="n", 
            HelpText ="Name of packed animation")]
        public string PackedName { get; set; }

        [CommandOptionsValue("max_width",
            Alias = "mw",
            HelpText = "Max packed texture width default = 512 note width have higher order in packing",
            DefaultValue = 512)]
        public int MaxWidth { get; set; }

        [CommandOptionsValue("max_height",
            Alias = "mh",
            HelpText = "Max packed texture height default = 512",
            DefaultValue = 0)]
        public int MaxHeight { get; set; }

        [CommandOptionsValue("img_ext",
            Alias ="ie",
            HelpText = "Image extension default is '.png'",
            DefaultValue = ".png")]
        public string ImageFileExtension { get; set; }
    }
}
