using System;

namespace WebClient
{
    public interface HeadersBuilder<out Body> : HeadersBuilder
    {
        Body Header(string headerName, params string[] headerValues);

        Body Accept(params MediaType[] acceptableMediaTypes);

        Body AcceptCharset(params Charset[] acceptableCharsets);

        Body IfModifiedSince(long ifModifiedSince);

        Body IfNoneMatch(params String[] ifNoneMatches);
    }

    public interface HeadersBuilder
    {
        RequestEntity Build();
    }
}