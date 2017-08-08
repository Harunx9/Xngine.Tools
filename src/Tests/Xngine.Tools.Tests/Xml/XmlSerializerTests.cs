using System.Collections.Generic;
using System.Xml.Serialization;
using Xunit;
using FluentAssertions;

namespace Xngine.Tools.Tests.Xml
{
    public class XmlSerializerTests
    {

        private const string XML_TO_TEST =
"<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n"+
"<test>\r\n"+
"  <item id=\"1\" name=\"Test1\" />\r\n"+
"  <item id=\"2\" name=\"Test2\" />\r\n"+
"  <item id=\"3\" name=\"Test3\" />\r\n"+
"  <item id=\"4\" name=\"Test4\" />\r\n"+
"</test>";

        private readonly TestSerialize _serializable;

        public XmlSerializerTests()
        {
            _serializable = new TestSerialize();
            _serializable.Items.Add(new TestSerializeItem { Id = 1, Name = "Test1" });
            _serializable.Items.Add(new TestSerializeItem { Id = 2, Name = "Test2" });
            _serializable.Items.Add(new TestSerializeItem { Id = 3, Name = "Test3" });
            _serializable.Items.Add(new TestSerializeItem { Id = 4, Name = "Test4" });
        }

        [Fact]
        public void xml_class_can_be_serialized_to_string()
        {
            var serializer = new Xngine.Tools.Commons.Xml.XmlSerializer();

            var result = serializer.SerializeToXmlString(_serializable);

            result.Should().Be(XML_TO_TEST);
        }

        [Fact]
        public void xml_class_can_be_deserialized_from_string()
        {
            var serializer = new Xngine.Tools.Commons.Xml.XmlSerializer();

            var result = serializer.Deserialize<TestSerialize>(XML_TO_TEST);

            result.Items.Should().NotBeEmpty();

            result.Items[0].Id.Should().Be(1);
            result.Items[0].Name.Should().Be("Test1");
            result.Items[3].Id.Should().Be(4);
            result.Items[3].Name.Should().Be("Test4");
        }

        [XmlRoot("test")]
        public class TestSerialize
        {
            [XmlElement("item")]
            public List<TestSerializeItem> Items { get; set; }

            public TestSerialize()
            {
                Items = new List<TestSerializeItem>();
            }
        }

        public class TestSerializeItem
        {
            [XmlAttribute("id")]
            public int Id { get; set; }

            [XmlAttribute("name")]
            public string Name { get; set; }
        }
    }
}
