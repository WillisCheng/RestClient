using System;
using System.Collections.Specialized;

namespace WebClient
{
    public class RequestEntity : RequestEntity<object>
    {
        public RequestEntity(HttpMethod method, Uri uri, NameValueCollection headers = null)
            : base(method, uri, headers)
        {
        }
    }

    public class RequestEntity<T> : HttpEntity<T> where T : class
    {
        public RequestEntity(HttpMethod method, Uri uri, NameValueCollection headers = null, T body = default(T))
            : base(headers, body)
        {
            this.uri = uri;
            this.method = method;
        }

        public HttpMethod method { get; private set; }

        public Uri uri { get; private set; }

        public static BodyBuilder Method(HttpMethod method, Uri uri)
        {
            return new DefaultBodyBuilder(method, uri);
        }

        public static HeadersBuilder Get(Uri uri)
        {
            return Method(HttpMethod.GET, uri);
        }

        public static HeadersBuilder Head(Uri uri)
        {
            return Method(HttpMethod.HEAD, uri);
        }

        public static BodyBuilder Post(Uri uri)
        {
            return Method(HttpMethod.POST, uri);
        }

        public static BodyBuilder Put(Uri uri)
        {
            return Method(HttpMethod.PUT, uri);
        }

        public static BodyBuilder Patch(Uri uri)
        {
            return Method(HttpMethod.PATCH, uri);
        }

        public static HeadersBuilder Delete(Uri uri)
        {
            return Method(HttpMethod.DELETE, uri);
        }

        public static HeadersBuilder options(Uri uri)
        {
            return Method(HttpMethod.OPTIONS, uri);
        }
    }
}