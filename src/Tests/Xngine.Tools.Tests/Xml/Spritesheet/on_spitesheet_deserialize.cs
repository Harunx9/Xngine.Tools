using Xngine.Packer.Model.SerializableEntities;
using Xunit;
using FluentAssertions;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.Xml.Spritesheet
{
    public class on_spitesheet_deserialize : SpritesheetTestBase
    {
        private SpriteSheet result;

        protected override void Arrange() => serializer = new Xngine.Tools.Commons.Xml.XmlSerializer();


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
}
