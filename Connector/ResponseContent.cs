using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using Extensions;

namespace HttpRequestSender
{
    public class ResponseContent
    {
        public readonly string ContentType;

        public readonly string Raw;

        private ResponseContent(string contentType)
        {
            Headers = new Dictionary<string, string>();
            ContentType = contentType;
        }

        public ResponseContent(string contentType, byte[] response)
            : this(contentType)
        {
            MemoryStream memoryStream = null;
            try
            {
                memoryStream = new MemoryStream(response);
                byte[] responseByte;
                using (var decompressionStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                {
                    responseByte = decompressionStream.ReadToEnd();
                }
                Raw = Encoding.UTF8.GetString(responseByte);
            }
            catch (InvalidDataException)
            {
                Raw = Encoding.UTF8.GetString(response);
            }
            finally
            {
                if (memoryStream != null)
                {
                    memoryStream.Dispose();
                }
            }
        }

        public IDictionary<string, string> Headers { get; set; }
        public int StatusCode { get; set; }
    }
}