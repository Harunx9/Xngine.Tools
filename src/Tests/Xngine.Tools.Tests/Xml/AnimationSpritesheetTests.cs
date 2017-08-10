using Xunit;
using FluentAssertions;
using Xngine.Packer.Model.SerializableEntities;
using Xngine.Tools.Commons.Xml;

namespace Xngine.Tools.Tests.Xml
{
    public class AnimationSpritesheetTests
    {
        private const string SERIALIZED_XML_ANIMATIONS_SPRITESHEET =
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

        [Fact]
        public void animation_spriteseet_shoudl_be_serialized_to_correct_xml_string()
        {
            var aniamtionSpritesheet = new AnitationSpriteSheet();
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

            var serializer = new XmlSerializer();

            var result = serializer.SerializeToXmlString(aniamtionSpritesheet);

            result.Should().Be(SERIALIZED_XML_ANIMATIONS_SPRITESHEET);
        }

        [Fact]
        public void animation_spriteseet_shoudl_be_deserialized_to_correct_object_instannce()
        {

            var serializer = new XmlSerializer();

            var result = serializer.Deserialize<AnitationSpriteSheet>(SERIALIZED_XML_ANIMATIONS_SPRITESHEET);

            result.Animations.Count.Should().Be(2);
            result.Animations[0].Name.Should().Be("animationName1");
            result.Animations[0].FramesPerSecond.Should().Be(4);
            result.Animations[0].Frames.Count.Should().Be(4);

            result.Animations.Count.Should().Be(2);
            result.Animations[1].Name.Should().Be("animationName2");
            result.Animations[1].FramesPerSecond.Should().Be(4);
            result.Animations[1].Frames.Count.Should().Be(4);
        }
    }
}
