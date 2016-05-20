using System.Collections.Generic;
using Serialization;
using System.Text;

namespace HttpRequestSender
{
    public class Request<T> where T : class
    {
        public RequestContent Content { get; set; }

        public readonly T Body;

        public string Raw
        {
            get
            {
                if (Content != null)
                {
                    return Content.Raw;
                }
                return null;
            }
        }

        public string ContentType
        {
            get
            {
                if (Content != null)
                {
                    return Content.ContentType;
                }
                return null;
            }
        }

        public IDictionary<string, string> Headers
        {
            get
            {
                if (Content != null)
                {
                    return Content.Headers;
                }
                return null;
            }
        }

        public Request(string contentType, T body)
        {
            Body = body;
            var serializer = SerializerFactory.GetSerializer(contentType);
            Content = new RequestContent(contentType, Encoding.UTF8.GetString(serializer.Serialize(body, typeof(T))));
        }

        public Request(string contentType, string request)
        {
            Content = new RequestContent(request, contentType);
            var serializer = SerializerFactory.GetSerializer(Content.ContentType);
            Body = serializer.Deserialize(typeof(T), Encoding.UTF8.GetBytes(request)) as T;
        }
    }
}