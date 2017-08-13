using Xngine.Packer.Model.SerializableEntities;
using Xunit;
using FluentAssertions;
using Xngine.Tools.Commons.Xml;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.Xml
{
    public class on_spitesheet_serialize : SpritesheetTestBase
    {
        private SpriteSheet spritesheet;
        private string result;

        protected override void Arrange()
        {
            spritesheet = new SpriteSheet();
            spritesheet.Add(new Item("Anim_1", 0, 0, 50, 50, 0, 0))
                .Add(new Item("Anim_2", 0, 50, 50, 50, 0, 0))
                .Add(new Item("Anim_3", 50, 0, 50, 50, 0, 0))
                .Add(new Item("Anim_4", 50, 50, 50, 50, 0, 0));

            serializer = new XmlSerializer();
        }

        protected override void Act()
            => result = serializer.SerializeToXmlString(spritesheet);

        [Assert]
        public void serialized_spritesheet_should_have_valid_schema()
            => result.Should().Be(SERIALIZED_XML_SPRITESHEET);
    }

    public class on_spitesheet_deserialize : SpritesheetTestBase
    {
        private SpriteSheet result;

        protected override void Arrange() => serializer = new XmlSerializer();


        protected override void Act()
            => result = serializer.Deserialize<SpriteSheet>(SERIALIZED_XML_SPRITESHEET);


        [Assert]
        public void deserialized_spritesheet_should_4_items_in_it()
            => result.Items.Count.Should().Be(4);

        [Assert]
        public void first_element_should_have_correct_values()
        {
            var elem = result.Items[0];
            elem.Name.Should().Be("Anim_1");
            elem.X.Should().Be(0);
            elem.Y.Should().Be(0);
            elem.Width.Should().Be(50);
            elem.Height.Should().Be(50);
        }

        [Assert]
        public void second_element_should_have_correct_values()
        {
            var elem = result.Items[1];
            elem.Name.Should().Be("Anim_2");
            elem.X.Should().Be(0);
            elem.Y.Should().Be(50);
            elem.Width.Should().Be(50);
            elem.Height.Should().Be(50);
        }

        [Assert]
        public void third_element_should_have_correct_values()
        {
            var elem = result.Items[2];
            elem.Name.Should().Be("Anim_3");
            elem.X.Should().Be(50);
            elem.Y.Should().Be(0);
            elem.Width.Should().Be(50);
            elem.Height.Should().Be(50);
        }

        [Assert]
        public void fourth_element_should_have_correct_values()
        {
            var elem = result.Items[3];
            elem.Name.Should().Be("Anim_4");
            elem.X.Should().Be(50);
            elem.Y.Should().Be(50);
            elem.Width.Should().Be(50);
            elem.Height.Should().Be(50);
        }
    }

    public abstract class SpritesheetTestBase : AAATest
    {
        protected XmlSerializer serializer;
        protected const string SERIALIZED_XML_SPRITESHEET =
    "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n" +
    "<spritesheet>\r\n" +
    "  <item name=\"Anim_1\" x=\"0\" y=\"0\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
    "  <item name=\"Anim_2\" x=\"0\" y=\"50\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
    "  <item name=\"Anim_3\" x=\"50\" y=\"0\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
    "  <item name=\"Anim_4\" x=\"50\" y=\"50\" width=\"50\" height=\"50\" offsetx=\"0\" offsety=\"0\" />\r\n" +
    "</spritesheet>";
    }
}
