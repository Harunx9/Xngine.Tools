using System.Collections.Generic;
using Xngine.Tools.Tests.BaseFramework;
using System.Xml.Serialization;

namespace Xngine.Tools.Tests.Xml.XmlSerializer
{
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
