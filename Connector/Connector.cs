using System;
using System.IO;
using System.Net;
using Extensions;

namespace HttpRequestSender
{
    public class Connector
    {
        private readonly string _method;
        private readonly string _uri;

        private HttpWebRequest _httpWebRequest;

        public Connector(string uri, string method)
        {
            _uri = uri;
            _method = method;
        }

        public ResponseContent Send(RequestContent request)
        {
            var uri = ValidateUri();
            if (uri == null)
            {
                return null;
            }
            var httpWebRequest = WebRequest.Create(uri) as HttpWebRequest;
            if (httpWebRequest == null)
            {
                return null;
            }
            _httpWebRequest = httpWebRequest;

            var method = ValidateMethod();
            if (method == null)
            {
                return null;
            }
            _httpWebRequest.Method = method.ToString();
            if (!string.IsNullOrEmpty(request.ContentType))
            {
                _httpWebRequest.ContentType = request.ContentType;
            }

            if (request.Headers != null)
            {
                foreach (var header in request.Headers)
                {
                    if (header.Key.Equals("Content-Type", StringComparison.OrdinalIgnoreCase))
                    {
                        _httpWebRequest.ContentType = header.Value;
                        continue;
                    }
                    if (header.Key.Equals("Accept", StringComparison.OrdinalIgnoreCase))
                    {
                        _httpWebRequest.Accept = header.Value;
                        continue;
                    }
                    _httpWebRequest.Headers.Add(header.Key, header.Value);
                }
            }

            if (method.Equals(HttpMethod.PUT) || method.Equals(HttpMethod.POST))
            {
                using (var streamWriter = new StreamWriter(_httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(request.Raw);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
            }
            ResponseContent response = null;
            HttpWebResponse webResponse = null;
            try
            {
                webResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            }
            catch (WebException e)
            {
                webResponse = e.Response as HttpWebResponse;
            }
            finally
            {
                if (webResponse != null)
                {
                    byte[] bytesToRead;
                    using (var responseStream = webResponse.GetResponseStream())
                    {
                        bytesToRead = responseStream.ReadToEnd();
                    }

                    response = new ResponseContent(webResponse.ContentType, bytesToRead)
                    {
                        StatusCode = (int) webResponse.StatusCode
                    };

                    foreach (var headerKey in webResponse.Headers.AllKeys)
                    {
                        response.Headers.Add(headerKey, webResponse.Headers[headerKey]);
                    }

                    webResponse.Close();
                }
            }

            return response;
        }

        //public Response<RS> Send<RQ, RS>(Request<RQ> request)
        //    where RQ : class
        //    where RS : class
        //{
        //    //return new Response<RS>(Send(request.Content);
        //}

        //public Response<RS> Send<RQ, RS>(Request<RQ> request)
        //    where RQ : class
        //    where RS : class
        //{
        //    var uri = ValidateUri();
        //    if (uri == null)
        //    {
        //        return null;
        //    }
        //    var httpWebRequest = WebRequest.Create(uri) as HttpWebRequest;
        //    if (httpWebRequest == null)
        //    {
        //        return null;
        //    }
        //    _httpWebRequest = httpWebRequest;

        //    var method = ValidateMethod();
        //    if (method == null)
        //    {
        //        return null;
        //    }
        //    _httpWebRequest.Method = method.ToString();
        //    if (!string.IsNullOrEmpty(request.ContentType))
        //    {
        //        _httpWebRequest.ContentType = request.ContentType;
        //    }

        //    if (request.Headers != null)
        //    {
        //        foreach (var header in request.Headers)
        //        {
        //            _httpWebRequest.Headers.Add(header.Key, header.Value);
        //        }
        //    }

        //    if (method.Equals(HttpMethod.PUT) || method.Equals(HttpMethod.POST))
        //    {
        //        using (var streamWriter = new StreamWriter(_httpWebRequest.GetRequestStream()))
        //        {
        //            streamWriter.Write(request.Raw);
        //            streamWriter.Flush();
        //            streamWriter.Close();
        //        }
        //    }

        //    Response<RS> response = null;
        //    HttpWebResponse webResponse = null;
        //    try
        //    {
        //        webResponse = httpWebRequest.GetResponse() as HttpWebResponse;
        //    }
        //    catch (WebException e)
        //    {
        //        webResponse = e.Response as HttpWebResponse;
        //    }
        //    finally
        //    {
        //        if (webResponse != null)
        //        {
        //            byte[] bytesToRead;
        //            using (var responseStream = webResponse.GetResponseStream())
        //            {
        //                bytesToRead = responseStream.ReadToEnd();
        //            }

        //            response = new Response<RS>(webResponse.ContentType, bytesToRead);

        //            foreach (var headerKey in webResponse.Headers.AllKeys)
        //            {
        //                response.Headers.Add(headerKey, webResponse.Headers[headerKey]);
        //            }

        //            webResponse.Close();
        //        }
        //    }

        //    return response;
        //}

        private Uri ValidateUri()
        {
            if (string.IsNullOrWhiteSpace(_uri))
            {
                throw new Exception("Uri is required.");
            }
            var uri = new Uri(_uri);
            return uri;
        }

        private HttpMethod? ValidateMethod()
        {
            if (string.IsNullOrWhiteSpace(_method))
            {
                throw new Exception("Method is required.");
            }
            HttpMethod method;
            if (Enum.TryParse(_method, true, out method))
            {
                return method;
            }
            throw new Exception(string.Format("Method '{0}' is not supported.", _method));
        }
    }
}