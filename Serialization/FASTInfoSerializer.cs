using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    public class FASTInfoSerializer : ISerializer
    {
        public static string ContentTypeForFast = "application/fastinfoset";

        public string ContentType
        {
            get
            {
                return FASTInfoSerializer.ContentTypeForFast;
            }
        }

        public byte[] Serialize(object objectRoot, System.Type objectType)
        {
            return Factory.Serialize(objectRoot, objectType, ContentTypeForFast, false);
        }

        public object Deserialize(System.Type returnType, System.IO.Stream strm)
        {
            return Factory.Deserialize(returnType, strm, FASTInfoSerializer.ContentTypeForFast, false);
        }

        public object Deserialize(System.Type returnType, byte[] bytes)
        {
            object result;
            using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream(bytes))
            {
                result = this.Deserialize(returnType, memoryStream);
            }
            return result;
        }

        public System.Xml.XmlReader GetReader(System.IO.Stream strm, System.Xml.XmlReaderSettings settings)
        {
            return System.Xml.XmlReader.Create(Factory.GetReader(strm, FASTInfoSerializer.ContentTypeForFast), settings);
        }

        public System.Xml.XmlReader GetReader(byte[] bytes, System.Xml.XmlReaderSettings settings)
        {
            return System.Xml.XmlReader.Create(Factory.GetReader(bytes, FASTInfoSerializer.ContentTypeForFast), settings);
        }
    }
}
