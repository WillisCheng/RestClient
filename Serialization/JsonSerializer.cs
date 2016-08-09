using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace Serialization
{
    public class JsonSerializer : ISerializer
    {
        public string ContentType
        {
            get { return "application/json"; }
        }

        public byte[] Serialize(object objectRoot, Type objectType)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(objectRoot, Formatting.Indented));
        }

        public object Deserialize(Type returnType, byte[] bytes)
        {
            object result;
            using (var memoryStream = new MemoryStream(bytes))
            {
                result = Deserialize(returnType, memoryStream);
            }
            return result;
        }

        public object Deserialize(Type returnType, Stream strm)
        {
            object result;
            using (var streamReader = new StreamReader(strm))
            {
                result = JsonConvert.DeserializeObject(streamReader.ReadToEnd(), returnType, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
            return result;
        }
    }
}