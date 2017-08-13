using Xunit;
using Xngine.Packer.Model.SerializableEntities;
using Xngine.Tools.Tests.BaseFramework;
using FluentAssertions;

namespace Xngine.Tools.Tests.Xml.AnimationSpritesheet
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

            serializer = new Tools.Commons.Xml.XmlSerializer();
        }

        protected override void Act()
            => result = serializer.SerializeToXmlString(aniamtionSpritesheet);


        [Assert]
        public void animation_spriteseet_shoudl_be_serialized_to_correct_xml_string()
            => result.Should().Be(SERIALIZED_XML_ANIMATIONS_SPRITESHEET);
    }
}
