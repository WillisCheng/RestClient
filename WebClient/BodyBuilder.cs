using System;

namespace WebClient
{
    public interface BodyBuilder : HeadersBuilder<BodyBuilder>
    {
        BodyBuilder ContentLength(long contentLength);

        BodyBuilder ContentType(MediaType contentType);
    }

    public class DefaultBodyBuilder : BodyBuilder
    {
        private readonly HttpMethod method;

        private readonly Uri uri;

        private readonly HttpHeaders headers = new HttpHeaders();

        public DefaultBodyBuilder(HttpMethod method, Uri uri)
        {
            this.method = method;
            this.uri = uri;
        }

        public BodyBuilder Header(String headerName, params String[] headerValues)
        {
            foreach (var headerValue in headerValues)
            {
                headers.Add(headerName, headerValue);
            }
            return this;
        }

        public BodyBuilder Accept(params MediaType[] acceptableMediaTypes)
        {
            headers.SetAccept(acceptableMediaTypes);
            return this;
        }

        public BodyBuilder AcceptCharset(params Charset[] acceptableCharsets)
        {
            headers.SetAcceptCharset(acceptableCharsets);
            return this;
        }

        public BodyBuilder ContentLength(long contentLength)
        {
            headers.SetContentLength(contentLength);
            return this;
        }

        public BodyBuilder ContentType(MediaType contentType)
        {
            headers.SetContentType(contentType);
            return this;
        }

        public BodyBuilder IfModifiedSince(long ifModifiedSince)
        {
            headers.SetIfModifiedSince(ifModifiedSince);
            return this;
        }

        public BodyBuilder IfNoneMatch(params String[] ifNoneMatches)
        {
            headers.SetIfNoneMatch(ifNoneMatches);
            return this;
        }

        public RequestEntity Build()
        {
            return new RequestEntity(method, uri, headers);
        }

        public RequestEntity<T> Body<T>(T body) where T : class
        {
            return new RequestEntity<T>(method, uri, headers, body);
        }
    }
}