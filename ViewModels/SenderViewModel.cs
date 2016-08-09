using Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using HttpRequestSender;

namespace ViewModels
{
    public class SenderViewModel : BaseViewModel
    {
        private readonly ObservableCollection<HeaderMap> RequestHeadersForm = new ObservableCollection<HeaderMap>();

        public string RequestHeaders
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in RequestHeadersForm)
                {
                    sb.AppendLine(item.ToString());
                }
                return sb.ToString();
            }
            set
            {
                RequestHeadersForm.Clear();
                LoadRequestHeaders(value);
            }
        }

        public string ResponseHeaders { get; set; }

        private string _uri;

        public string Uri
        {
            get { return _uri; }
            set
            {
                _uri = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> SupportedMethods { get; set; }

        public string _method;

        public string Method
        {
            get { return _method; }
            set
            {
                _method = value;
                OnPropertyChanged();
            }
        }

        private string _requestContent;

        public string RequestContent
        {
            get { return _requestContent; }
            set
            {
                _requestContent = value;
                OnPropertyChanged();
            }
        }

        private int _statusCode;

        public int StatusCode
        {
            get { return _statusCode; }
            set
            {
                _statusCode = value;
                OnPropertyChanged();
            }
        }

        private int _duration;

        public int Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
                OnPropertyChanged();
            }
        }

        private string _responseContent;

        public string ResponseContent
        {
            get { return _responseContent; }
            set
            {
                _responseContent = value;
                OnPropertyChanged();
            }
        }

        public SenderViewModel()
        {
            RequestHeadersForm.Add(HeaderMap.Default);
            SupportedMethods = new ObservableCollection<string>(Enum.GetNames(typeof(HttpMethod)));
            Method = HttpMethod.GET.ToString();
        }

        private void LoadRequestHeaders(string requestHeaders)
        {
            if (string.IsNullOrWhiteSpace(requestHeaders)) return;
            var headers = requestHeaders.Trim().Split('\r', '\t');
            foreach (var header in headers)
            {
                var item = header.Split(':');
                if (item.Length == 2)
                {
                    var key = item[0].Replace("\n", "").Trim();
                    var headerItem = RequestHeadersForm.FirstOrDefault(c => c.Key.Equals(key, StringComparison.OrdinalIgnoreCase));
                    if (headerItem != null)
                    {
                        headerItem.Value = item[1];
                    }
                    else
                    {
                        RequestHeadersForm.Add(new HeaderMap { Key = key, Value = item[1] });
                    }
                }
            }
        }

        public void Send()
        {
            var connector = new Connector(Uri, Method);
            var requestHeaders = RequestHeadersForm.ToDictionary(item => item.Key, item => item.Value);
            var contentType = requestHeaders.GetValue("Content-Type", StringComparer.OrdinalIgnoreCase);
            var requestContent = new RequestContent(RequestContent, contentType)
            {
                Headers = requestHeaders
            };
            var start = DateTime.Now;
            var response = connector.Send(requestContent);
            var end = DateTime.Now;
            StatusCode = response.StatusCode;
            Duration = (end - start).Milliseconds;
            LoadResponseBody(response.Raw);
            LoadResponseHeaders(response.Headers);
        }

        private void LoadResponseBody(string content)
        {
            ResponseContent = content;
        }

        private void LoadResponseHeaders(IDictionary<string, string> headers)
        {
            var sbResponseHeader = new StringBuilder();
            foreach (var header in headers)
            {
                sbResponseHeader.AppendLine(header.ToString());
            }
            ResponseHeaders = sbResponseHeader.ToString();
        }
    }
}