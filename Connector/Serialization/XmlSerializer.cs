using System;
using System.IO;

namespace Serialization
{
    public class XmlSerializer : ISerializer
    {
        public static string ContentTypeForXml = "text/xml";

        public string ContentType
        {
            get
            {
                return ContentTypeForXml;
            }
        }

        public byte[] Serialize(object objectRoot, Type objectType)
        {
            byte[] result;
            using (var memoryStream = SerializeToStream(objectRoot, objectType))
            {
                result = memoryStream.ToArray();
            }
            return result;
        }

        private static MemoryStream SerializeToStream(object objectRoot, Type objectType)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(objectType);
            var memoryStream = new MemoryStream();
            xmlSerializer.Serialize(memoryStream, objectRoot);
            memoryStream.Position = 0L;
            return memoryStream;
        }

        public object Deserialize(Type returnType, Stream strm)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(returnType);
            return xmlSerializer.Deserialize(strm);
        }

        public object Deserialize(Type returnType, byte[] bytes)
        {
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(returnType);
            object result;
            using (var memoryStream = new MemoryStream(bytes))
            {
                result = xmlSerializer.Deserialize(memoryStream);
            }
            return result;
        }
    }
}