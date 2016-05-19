using Serialization;
using System.Collections.Generic;

namespace HttpRequestSender
{
    public class Response<T> where T : class
    {
        public IDictionary<string, string> Headers { get; set; }
        public int StatusCode { get; set; }

        public readonly string Raw;

        public readonly string ContentType;

        public readonly T Body;

        private readonly ISerializer serializer;

        private Response(string contentType)
        {
            Headers = new Dictionary<string, string>();
            ContentType = contentType;
            serializer = SerializerFactory.GetSerializer(contentType);
        }

        public Response(string contentType, byte[] response)
            : this(contentType)
        {
            Raw = System.Text.Encoding.UTF8.GetString(response);
            Body = serializer.Deserialize(typeof(T), response) as T;
        }
        
    }
}