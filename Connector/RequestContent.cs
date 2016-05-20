using System.Collections.Generic;

namespace HttpRequestSender
{
    public class RequestContent
    {
        public IDictionary<string, string> Headers { get; set; }

        public readonly string Raw;

        public readonly string ContentType;

        private RequestContent(string contentType)
        {
            ContentType = contentType;
        }

        public RequestContent(string request, string contentType)
            : this(contentType)
        {
            Raw = request;
        }
    }
}