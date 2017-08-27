using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Xngine.Packer.Model.ImageProcessing;

namespace Xngine.Packer.Model.SerializableEntities
{
    // Animation xml scheme with names
    //<animations>
    //    <animation name="animationName1" framesPerSecond="4">
    //        <frame number="0" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //        <frame number="1" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //        <frame number="2" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //        <frame number="3" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //    </animation>
    //    <animation name="animationName2" framesPerSecond="4">
    //        <frame number="0" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //        <frame number="1" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //        <frame number="2" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //        <frame number="3" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //    </animation>
    //</animations>

    [XmlRoot("animations")]
    public class AnitationSpriteSheet
    {
        [XmlElement("animation")]
        public List<Animation> Animations { get; set; }


        public AnitationSpriteSheet()
        {
            Animations = new List<Animation>();
        }


        public AnitationSpriteSheet Add(Animation animation)
        {
            Animations.Add(animation);
            return this;
        }

        public static AnitationSpriteSheet Create<T>(SpriteSheetConfig<T> spriteSheetConfig, string namePattern)
        {
            var sheet = new AnitationSpriteSheet();

            foreach (var descriptor in spriteSheetConfig.Descriptors)
            {
                var mathes = Regex.Match(descriptor.Name, namePattern);

                var animationName = mathes.Groups["animationname"];
                var animation = sheet.Animations.FirstOrDefault(x => x.Name == animationName.Value);
                if (animation != null)
                {
                    AddFrame(spriteSheetConfig, descriptor, mathes, animation);
                }
                else
                {
                    animation = new Animation(animationName.Value, 4);
                    AddFrame(spriteSheetConfig, descriptor, mathes, animation);
                    sheet.Add(animation);
                }
            }

            return sheet;
        }

        private static void AddFrame<T>(SpriteSheetConfig<T> spriteSheetConfig, ImageDescriptor descriptor, Match mathes, Animation animation)
        {
            var frameNumber = mathes.Groups["framenumber"];
            animation.Add(new Frame(int.Parse(frameNumber.Value),
                descriptor.X, descriptor.Y, descriptor.Width,
                descriptor.Height, spriteSheetConfig.OffsetX,
                spriteSheetConfig.OffsetY));
        }
    }

    public class Animation
    {
        [XmlElement("frame")]
        public List<Frame> Frames { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("framesPerSecond")]
        public int FramesPerSecond { get; set; }

        private Animation(){}

        public Animation(string name, int framesPerSecond)
        {
            Name = name;
            FramesPerSecond = framesPerSecond;
            Frames = new List<Frame>();
        }

        public Animation Add(Frame frame)
        {
            Frames.Add(frame);
            return this;
        }
    }

    public class Frame 
    {
        [XmlAttribute("number")]
        public int Number { get; set; }

        [XmlAttribute("x")]
        public int X { get; set; }

        [XmlAttribute("y")]
        public int Y { get; set; }

        [XmlAttribute("width")]
        public int Width { get; set; }

        [XmlAttribute("height")]
        public int Height { get; set; }

        [XmlAttribute("offsetx")]
        public int OffsetX { get; set; }

        [XmlAttribute("offsety")]
        public int OffsetY { get; set; }

        private Frame(){}

        public Frame(int number, int x, int y, int width, int height, int offsetX, int offsetY)
        {
            Number = number;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            OffsetX = offsetX;
            OffsetY = offsetY;
        }

    }
}
