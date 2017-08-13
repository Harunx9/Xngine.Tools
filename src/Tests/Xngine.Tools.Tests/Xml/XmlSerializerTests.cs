using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using Xngine.Tools.Tests.BaseFramework;
using System.Xml.Serialization;

namespace Xngine.Tools.Tests.Xml
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

    public abstract class XmlSerializerBase : AAATest
    {
        protected Xngine.Tools.Commons.Xml.XmlSerializer serializer;
        protected const string XML_TO_TEST =
    "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n" +
    "<test>\r\n" +
    "  <item id=\"1\" name=\"Test1\" />\r\n" +
    "  <item id=\"2\" name=\"Test2\" />\r\n" +
    "  <item id=\"3\" name=\"Test3\" />\r\n" +
    "  <item id=\"4\" name=\"Test4\" />\r\n" +
    "</test>";

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
