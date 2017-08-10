using System.Text;
using Xngine.Packer.Model.SerializableEntities;
using Xunit;
using FluentAssertions;
using Xngine.Tools.Commons.Xml;

namespace Xngine.Tools.Tests.Xml
{
    public class SpritesheetTest
    {
        private const string SERIALIZED_XML_SPRITESHEET =
@"<?xml version=""1.0"" encoding=""utf-16""?>
<spritesheet>
  <item name=""Anim_1"" x=""0"" y=""0"" width=""50"" height=""50"" offsetx=""0"" offsety=""0"" />
  <item name=""Anim_2"" x=""0"" y=""50"" width=""50"" height=""50"" offsetx=""0"" offsety=""0"" />
  <item name=""Anim_3"" x=""50"" y=""0"" width=""50"" height=""50"" offsetx=""0"" offsety=""0"" />
  <item name=""Anim_4"" x=""50"" y=""50"" width=""50"" height=""50"" offsetx=""0"" offsety=""0"" />
</spritesheet>";

        [Fact]
        public void serialized_spritesheet_should_have_valid_schema()
        {
            var spritesheet = new SpriteSheet();
            spritesheet.Add(new Item("Anim_1", 0, 0, 50, 50, 0, 0))
                .Add(new Item("Anim_2", 0, 50, 50, 50, 0, 0))
                .Add(new Item("Anim_3", 50, 0, 50, 50, 0, 0))
                .Add(new Item("Anim_4", 50, 50, 50, 50, 0, 0));

            var serializer = new XmlSerializer();

            var result = serializer.SerializeToXmlString<SpriteSheet>(spritesheet);

            result.Should().Be(SERIALIZED_XML_SPRITESHEET);
        }

        [Fact]
        public void deserialized_spritesheet_should_have_valid_schema()
        {
            var serializer = new XmlSerializer();

            var result = serializer.Deserialize<SpriteSheet>(SERIALIZED_XML_SPRITESHEET);

            result.Items.Count.Should().Be(4);
            result.Items[0].Name.Should().Be("Anim_1");
            result.Items[1].Name.Should().Be("Anim_2");
            result.Items[2].Name.Should().Be("Anim_3");
            result.Items[3].Name.Should().Be("Anim_4");
        }
    }
}
