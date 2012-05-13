namespace Schematismi.Common.Utils
{
    using System.Xml.Linq;
    using System.Xml.Serialization;

    public class SerializerHelper
    {
        public static T DeserializeFromString<T>(string str)
        {
            XDocument doc = XDocument.Parse(str);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            XmlSerializerNamespaces xmlnsEmpty = new XmlSerializerNamespaces();
            xmlnsEmpty.Add("", "");

            using (var reader = doc.CreateReader())
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        public static T DeserializeFromXDocument<T>(XDocument doc)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            XmlSerializerNamespaces xmlnsEmpty = new XmlSerializerNamespaces();
            xmlnsEmpty.Add("", "");

            using (var reader = doc.CreateReader())
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        public static T DeserializeFromPath<T>(string str)
        {
            XDocument doc = XDocument.Load(str);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            XmlSerializerNamespaces xmlnsEmpty = new XmlSerializerNamespaces();
            xmlnsEmpty.Add("", "");

            using (var reader = doc.CreateReader())
            {
                return (T)xmlSerializer.Deserialize(reader);
            }
        }

        public static XDocument Serialize<T>(T value)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            XmlSerializerNamespaces xmlnsEmpty = new XmlSerializerNamespaces();
            xmlnsEmpty.Add("", "");

            XDocument doc = new XDocument();
            using (var writer = doc.CreateWriter())
            {
                xmlSerializer.Serialize(writer, value, xmlnsEmpty);
            }

            return doc;
        }
    }
}