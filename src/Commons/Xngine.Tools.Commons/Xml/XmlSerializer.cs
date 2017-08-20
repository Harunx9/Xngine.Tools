using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Xngine.Tools.Commons.Ioc;

namespace Xngine.Tools.Commons.Xml
{
    public interface IXmlSerializer
    {
        string SerializeToXmlString<T>(T entity) where T : class;
        T Deserialize<T>(string xmlString) where T : class;
        T Deserialize<T>(FileStream file) where T : class;
    }

    [Dependency]
    public class XmlSerializer : IXmlSerializer
    {
        public T Deserialize<T>(string xmlString) where T : class
        {
            var seriazier = new System.Xml.Serialization.XmlSerializer(typeof(T));

            T result = default(T);

            using (var reader = new StringReader(xmlString))
            {
                result = seriazier.Deserialize(reader) as T;
            }

            return result;
        }

        public T Deserialize<T>(FileStream file) where T : class
        {
            var seriazier = new System.Xml.Serialization.XmlSerializer(typeof(T));

            T result = default(T);

            using (var reader = XmlReader.Create(file))
            {
                result = seriazier.Deserialize(reader) as T;
            }

            return result;
        }

        public string SerializeToXmlString<T>(T entity) where T : class
        {
            var seriazier = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            var xmlWriterSettings = new XmlWriterSettings() { Indent = true, IndentChars= "  " };

            var builder = new StringBuilder();
            using (var writer = XmlWriter.Create(builder, xmlWriterSettings))
            {
                seriazier.Serialize(writer, entity, namespaces);
            }

            return builder.ToString();
        }
    }
}
