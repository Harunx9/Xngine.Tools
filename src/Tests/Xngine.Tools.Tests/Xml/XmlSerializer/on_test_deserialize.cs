using FluentAssertions;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.Xml.XmlSerializer
{
    public class on_test_deserialize : XmlSerializerBase
    {
        private TestSerialize result;

        protected override void Arrange()
        {
            serializer = new Xngine.Tools.Commons.Xml.XmlSerializer();
        }

        protected override void Act()
        {
            result = serializer.Deserialize<TestSerialize>(XML_TO_TEST);
        }

        [Assert]
        public void deserialized_object_should_not_be_empty()
            => result.Items.Should().NotBeEmpty();

        [Assert]
        public void first_object_should_have_correct_values()
        {
            result.Items[0].Id.Should().Be(1);
            result.Items[0].Name.Should().Be("Test1");
        }

        [Assert]
        public void second_object_should_have_correct_values()
        {
            result.Items[1].Id.Should().Be(2);
            result.Items[1].Name.Should().Be("Test2");
        }

        [Assert]
        public void third_object_should_have_correct_values()
        {
            result.Items[2].Id.Should().Be(3);
            result.Items[2].Name.Should().Be("Test3");
        }

        [Assert]
        public void fourth_object_should_have_correct_values()
        {
            result.Items[3].Id.Should().Be(4);
            result.Items[3].Name.Should().Be("Test4");
        }
    }
}
