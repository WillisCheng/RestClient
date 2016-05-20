using Extensions;
using HttpRequestSender;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ViewModels
{
    public class SenderViewModel : BaseViewModel
    {
        public readonly ObservableCollection<Tuple<string, string>> RequestHeaders = new ObservableCollection<Tuple<string, string>>();

        public Dictionary<string, string> ResponseHeaders { get; set; }
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
            ResponseHeaders = new Dictionary<string, string>();
        }

        public void Send()
        {
            var connector = new Connector(Uri, Method);
            var requestHeaders = RequestHeaders.ToDictionary(item => item.Item1, item => item.Item2);
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
            ResponseContent = response.Raw;
            ResponseHeaders.Clear();
            foreach (var header in response.Headers)
            {
                ResponseHeaders.Add(header.Key, header.Value);
            }
        }
    }
}