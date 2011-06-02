using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace harvestsharp
{
    public static class Extensions
    {
        public static XElement ToXElement<T>(this T obj)
        {
            XmlSerializerNamespaces emptyNamespace = new XmlSerializerNamespaces();
            emptyNamespace.Add(String.Empty, String.Empty);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            XmlWriterSettings writerSettings = new XmlWriterSettings();
            writerSettings.OmitXmlDeclaration = true;
            StringWriter stringWriter = new StringWriter();
            using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, writerSettings))
            {
                xmlSerializer.Serialize(xmlWriter, obj, emptyNamespace);
            }
            return XElement.Parse(stringWriter.ToString());
        }
    }
}
