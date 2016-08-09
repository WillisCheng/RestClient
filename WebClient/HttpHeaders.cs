using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace WebClient
{
    public sealed class HttpHeaders : NameValueCollection
    {
        public const string ACCEPT = "Accept";
        public const string ACCEPT_CHARSET = "Accept-Charset";
        public const string ACCEPT_ENCODING = "Accept-Encoding";
        public const string ACCEPT_LANGUAGE = "Accept-Language";
        public const string ACCEPT_RANGES = "Accept-Ranges";
        public const string AGE = "Age";
        public const string ALLOW = "Allow";
        public const string AUTHORIZATION = "Authorization";
        public const string CACHE_CONTROL = "Cache-Control";
        public const string CONNECTION = "Connection";
        public const string CONTENT_ENCODING = "Content-Encoding";
        public const string CONTENT_DISPOSITION = "Content-Disposition";
        public const string CONTENT_LANGUAGE = "Content-Language";
        public const string CONTENT_LENGTH = "Content-Length";
        public const string CONTENT_LOCATION = "Content-Location";
        public const string CONTENT_RANGE = "Content-Range";
        public const string CONTENT_TYPE = "Content-Type";
        public const string COOKIE = "Cookie";
        public const string DATE = "Date";
        public const string ETAG = "ETag";
        public const string EXPECT = "Expect";
        public const string EXPIRES = "Expires";
        public const string FROM = "From";
        public const string HOST = "Host";
        public const string IF_MATCH = "If-Match";
        public const string IF_MODIFIED_SINCE = "If-Modified-Since";
        public const string IF_NONE_MATCH = "If-None-Match";
        public const string IF_RANGE = "If-Range";
        public const string IF_UNMODIFIED_SINCE = "If-Unmodified-Since";
        public const string LAST_MODIFIED = "Last-Modified";
        public const string LINK = "Link";
        public const string LOCATION = "Location";
        public const string MAX_FORWARDS = "Max-Forwards";
        public const string ORIGIN = "Origin";
        public const string PRAGMA = "Pragma";
        public const string PROXY_AUTHENTICATE = "Proxy-Authenticate";
        public const string PROXY_AUTHORIZATION = "Proxy-Authorization";
        public const string RANGE = "Range";
        public const string REFERER = "Referer";
        public const string RETRY_AFTER = "Retry-After";
        public const string SERVER = "Server";
        public const string SET_COOKIE = "Set-Cookie";
        public const string SET_COOKIE2 = "Set-Cookie2";
        public const string TE = "TE";
        public const string TRAILER = "Trailer";
        public const string TRANSFER_ENCODING = "Transfer-Encoding";
        public const string UPGRADE = "Upgrade";
        public const string USER_AGENT = "User-Agent";
        public const string VARY = "Vary";
        public const string VIA = "Via";
        public const string WARNING = "Warning";
        public const string WWW_AUTHENTICATE = "WWW-Authenticate";

        public HttpHeaders(IDictionary<string, string> headers = null)
        {
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    Add(header.Key, header.Value);
                }
            }
        }

        public void SetAccept(params MediaType[] acceptableMediaTypes)
        {
            if (acceptableMediaTypes != null)
            {
                Set(ACCEPT, string.Join(", ", acceptableMediaTypes));
            }
        }

        public IEnumerable<MediaType> GetAccept()
        {
            List<MediaType> acceptableMediaTypes = new List<MediaType>();
            string value = Get(ACCEPT);

            //List<MediaType> result = (value != null ? MediaType.parseMediaTypes(value) : Collections.<MediaType>emptyList());

            //// Some containers parse 'Accept' into multiple values
            //if (result.size() == 1) {
            //    List<String> acceptHeader = get(ACCEPT);
            //    if (acceptHeader.size() > 1) {
            //        value = StringUtils.collectionToCommaDelimitedString(acceptHeader);
            //        result = MediaType.parseMediaTypes(value);
            //    }
            //}

            return acceptableMediaTypes;
        }

        public void SetAcceptCharset(params Charset[] acceptableCharsets)
        {
            if (acceptableCharsets != null)
            {
                Set(ACCEPT_CHARSET, string.Join(", ", acceptableCharsets));
            }
        }

        public IEnumerable<Charset> GetAcceptCharset()
        {
            List<Charset> result = new List<Charset>();
            //String value = getFirst(ACCEPT_CHARSET);
            //if (value != null) {
            //    String[] tokens = value.split(",\\s*");
            //    for (String token : tokens) {
            //        int paramIdx = token.indexOf(';');
            //        String charsetName;
            //        if (paramIdx == -1) {
            //            charsetName = token;
            //        }
            //        else {
            //            charsetName = token.substring(0, paramIdx);
            //        }
            //        if (!charsetName.equals("*")) {
            //            result.add(Charset.forName(charsetName));
            //        }
            //    }
            //}
            return result;
        }

        public void SetAllow(params HttpMethod[] allowedMethods)
        {
            if (allowedMethods != null)
            {
                Set(ALLOW, string.Join(",", allowedMethods));
            }
        }

        public IEnumerable<HttpMethod> GetAllow()
        {
            //String value = getFirst(ALLOW);
            //if (!StringUtils.isEmpty(value)) {
            //    List<HttpMethod> allowedMethod = new ArrayList<HttpMethod>(5);
            //    String[] tokens = value.split(",\\s*");
            //    for (String token : tokens) {
            //        allowedMethod.add(HttpMethod.valueOf(token));
            //    }
            //    return EnumSet.copyOf(allowedMethod);
            //}
            //else {
            //    return EnumSet.noneOf(HttpMethod.class);
            //}
            return new List<HttpMethod>();
        }

        public void SetContentType(MediaType mediaType)
        {
            //Assert.isTrue(!mediaType.isWildcardType(), "'Content-Type' cannot contain wildcard type '*'");
            //Assert.isTrue(!mediaType.isWildcardSubtype(), "'Content-Type' cannot contain wildcard subtype '*'");
            Set(CONTENT_TYPE, mediaType.ToString());
        }

        //public MediaType getContentType()
        //{
        //    String value = Get(CONTENT_TYPE);
        //    return (StringUtils.hasLength(value) ? MediaType.parseMediaType(value) : null);
        //}

        public void SetContentLength(long contentLength)
        {
            Set(CONTENT_LENGTH, contentLength.ToString());
        }

        public void SetIfModifiedSince(long ifModifiedSince)
        {
            Set(IF_MODIFIED_SINCE, DateTime.FromFileTimeUtc(ifModifiedSince).ToString("EEE, dd MMM yyyy HH:mm:ss zzz"));
        }

        public void SetIfNoneMatch(params string[] ifNoneMatchList)
        {
            Set(IF_NONE_MATCH, string.Join(", ", ifNoneMatchList));
        }
    }
}