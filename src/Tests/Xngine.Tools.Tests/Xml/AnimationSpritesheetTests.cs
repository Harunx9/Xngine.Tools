using Xunit;
using FluentAssertions;
using Xngine.Packer.Model.SerializableEntities;
using Xngine.Tools.Commons.Xml;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.Xml
{
    public class on_animation_spritesheet_serialization : AnimationSpritesheetBase
    {
        private AnitationSpriteSheet aniamtionSpritesheet;
        private string result;

        protected override void Arrange()
        {
            aniamtionSpritesheet = new AnitationSpriteSheet();
            aniamtionSpritesheet.Add(new Animation("animationName1", 4)
                .Add(new Frame(0, 0, 0, 50, 50, 0, 0))
                .Add(new Frame(0, 50, 0, 50, 50, 0, 0))
                .Add(new Frame(0, 100, 0, 50, 50, 0, 0))
                .Add(new Frame(0, 150, 0, 50, 50, 0, 0)));
            aniamtionSpritesheet.Add(new Animation("animationName2", 4)
                .Add(new Frame(0, 0, 50, 50, 50, 0, 0))
                .Add(new Frame(0, 50, 50, 50, 50, 0, 0))
                .Add(new Frame(0, 100, 50, 50, 50, 0, 0))
                .Add(new Frame(0, 150, 50, 50, 50, 0, 0)));

            serializer = new XmlSerializer();
        }

        protected override void Act()
            => result = serializer.SerializeToXmlString(aniamtionSpritesheet);


        [Assert]
        public void animation_spriteseet_shoudl_be_serialized_to_correct_xml_string()
            => result.Should().Be(SERIALIZED_XML_ANIMATIONS_SPRITESHEET);
    }


    public class on_animation_spritesheet_deserialization : AnimationSpritesheetBase
    {
        private AnitationSpriteSheet result;

        protected override void Arrange()
        {
            serializer = new XmlSerializer();
        }

        protected override void Act()
           => result = serializer.Deserialize<AnitationSpriteSheet>(SERIALIZED_XML_ANIMATIONS_SPRITESHEET);

        [Assert]
        public void animation_spriteseet_should_have_2_animations()
           => result.Animations.Count.Should().Be(2);

        [Assert]
        public void firts_animation_spriteseet_should_have_correct_name_4_fps_and_4_frames()
        {
            result.Animations[0].Name.Should().Be("animationName1");
            result.Animations[0].FramesPerSecond.Should().Be(4);
            result.Animations[0].Frames.Count.Should().Be(4);
        }

        [Assert]
        public void second_animation_spriteseet_should_have_correct_name_4_fps_and_4_frames()
        {
            result.Animations[1].Name.Should().Be("animationName2");
            result.Animations[1].FramesPerSecond.Should().Be(4);
            result.Animations[1].Frames.Count.Should().Be(4);
        }
    }

    public abstract class AnimationSpritesheetBase : AAATest
    {
        protected XmlSerializer serializer;
        protected const string SERIALIZED_XML_ANIMATIONS_SPRITESHEET =
            "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n" +
            "<animations>\r\n" +
            "  <animation name=\"animationName1\" framesPerSecond=\"4\">\r\n" +
            "    <frame number=\"0\" x=\"0\" y=\"0\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "    <frame number=\"0\" x=\"50\" y=\"0\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "    <frame number=\"0\" x=\"100\" y=\"0\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "    <frame number=\"0\" x=\"150\" y=\"0\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "  </animation>\r\n" +
            "  <animation name=\"animationName2\" framesPerSecond=\"4\">\r\n" +
            "    <frame number=\"0\" x=\"0\" y=\"50\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "    <frame number=\"0\" x=\"50\" y=\"50\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "    <frame number=\"0\" x=\"100\" y=\"50\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "    <frame number=\"0\" x=\"150\" y=\"50\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
            "  </animation>\r\n" +
            "</animations>";
    }
}
