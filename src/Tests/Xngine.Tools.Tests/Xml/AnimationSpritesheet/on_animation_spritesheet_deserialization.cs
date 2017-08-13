using FluentAssertions;
using Xngine.Packer.Model.SerializableEntities;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.Xml.AnimationSpritesheet
{
    public class on_animation_spritesheet_deserialization : AnimationSpritesheetBase
    {
        private AnitationSpriteSheet result;

        protected override void Arrange()
        {
            serializer = new Xngine.Tools.Commons.Xml.XmlSerializer();
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
}
