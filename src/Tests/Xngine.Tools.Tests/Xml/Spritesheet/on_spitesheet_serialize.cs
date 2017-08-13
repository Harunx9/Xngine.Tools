using Xngine.Packer.Model.SerializableEntities;
using Xunit;
using Xngine.Tools.Tests.BaseFramework;
using FluentAssertions;

namespace Xngine.Tools.Tests.Xml.Spritesheet
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

            serializer = new Xngine.Tools.Commons.Xml.XmlSerializer();
        }

        protected override void Act()
            => result = serializer.SerializeToXmlString(spritesheet);

        [Assert]
        public void serialized_spritesheet_should_have_valid_schema()
            => result.Should().Be(SERIALIZED_XML_SPRITESHEET);
    }
}
