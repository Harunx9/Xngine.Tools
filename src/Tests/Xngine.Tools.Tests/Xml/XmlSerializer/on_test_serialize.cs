using FluentAssertions;
using Xngine.Tools.Tests.BaseFramework;

namespace Xngine.Tools.Tests.Xml.XmlSerializer
{
    public class on_test_serialize : XmlSerializerBase
    {
        private TestSerialize serializable;
        private string result;

        protected override void Arrange()
        {
            serializable = new TestSerialize();
            serializable.Items.Add(new TestSerializeItem { Id = 1, Name = "Test1" });
            serializable.Items.Add(new TestSerializeItem { Id = 2, Name = "Test2" });
            serializable.Items.Add(new TestSerializeItem { Id = 3, Name = "Test3" });
            serializable.Items.Add(new TestSerializeItem { Id = 4, Name = "Test4" });
            serializer = new Xngine.Tools.Commons.Xml.XmlSerializer();
        }

        protected override void Act()
        {
            result = serializer.SerializeToXmlString(serializable);
        }

        [Assert]
        public void xml_class_can_be_serialized_to_string()
            => result.Should().Be(XML_TO_TEST);
    }

}
