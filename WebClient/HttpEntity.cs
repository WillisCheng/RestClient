using System.Collections.Specialized;
using System.Text;

namespace WebClient
{
    //public class HttpEntity : HttpEntity<object>
    //{
    //    public HttpEntity(NameValueCollection headers = null)
    //        : base(headers)
    //    {
    //    }
    //}

    public class HttpEntity<T>
    {
        public static readonly HttpEntity<T> EMPTY = new HttpEntity<T>();
        public HttpHeaders headers { get; private set; }
        public T body { get; private set; }

        public HttpEntity(NameValueCollection headers = null, T body = default(T))
        {
            this.body = body;
            var tempHeaders = new HttpHeaders();
            if (headers != null)
            {
                tempHeaders.Add(headers);
            }
            this.headers = tempHeaders;
        }

        public override string ToString()
        {
            var builder = new StringBuilder("<");
            if (body != null)
            {
                builder.Append(body);
                if (headers != null)
                {
                    builder.Append(',');
                }
            }
            if (headers != null)
            {
                builder.Append(headers);
            }
            builder.Append('>');
            return builder.ToString();
        }
    }
}