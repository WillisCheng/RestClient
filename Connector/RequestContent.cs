using System.Collections.Generic;

namespace HttpRequestSender
{
    public class RequestContent
    {
        public readonly string ContentType;

        public readonly string Raw;

        private RequestContent(string contentType)
        {
            ContentType = contentType;
        }

        public RequestContent(string request, string contentType)
            : this(contentType)
        {
            Raw = request;
        }

        public IDictionary<string, string> Headers { get; set; }
    }
}