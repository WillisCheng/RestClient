using Extensions;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using ViewModels;

namespace SenderTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new SenderViewModel();
        }

        public SenderViewModel ViewModel
        {
            get
            {
                return DataContext as SenderViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        private readonly Dictionary<string, string> RequestHeaders = new Dictionary<string, string>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.Send();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.GetBaseException().Message);
            }

            //var uri = TxtUri.Text.Trim();
            //var method = CbbMethod.SelectionBoxItem.ToString();
            //var connector = new Connector(uri, method);
            //var requestBody = TxtRequestContent.Text.Trim();
            //LoadRequestHeaders();
            //var requestContent = new RequestContent(requestBody, RequestHeaders.GetValue("Content-Type", StringComparer.OrdinalIgnoreCase))
            //{
            //    Headers = RequestHeaders
            //};
            //DateTime start = DateTime.Now;
            //var response = connector.Send(requestContent);
            //DateTime end = DateTime.Now;
            //LbStatusCode.Content = response.StatusCode;
            //LbDuration.Content = string.Format("{0}ms", (end - start).Milliseconds);
            //LoadResponseBody(response.Raw);
            //LoadResponseHeaders(response.Headers);
        }

        //private void LoadRequestHeaders()
        //{
        //    var headers = TxtRequestHeaders.Text.Trim().Split('\r', '\t');
        //    foreach (var header in headers)
        //    {
        //        var item = header.Split(':');
        //        if (item.Length == 2)
        //        {
        //            var key = item[0].Replace("\n", "").Trim();
        //            RequestHeaders.AddOrUpdate(key, item[1].Trim(), StringComparer.OrdinalIgnoreCase);
        //        }
        //    }
        //    if (!RequestHeaders.ContainsKey("content-type", StringComparer.OrdinalIgnoreCase))
        //    {
        //        RequestHeaders["Content-Type"] = "text/plain";
        //    }
        //}

        //private void LoadResponseBody(string content)
        //{
        //    TxtResponseContent.Text = content;
        //}

        //private void LoadResponseHeaders(IDictionary<string, string> headers)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    foreach (var header in headers)
        //    {
        //        sb.AppendLine(string.Format("{0}:{1}", header.Key, header.Value));
        //    }
        //    TxtResponseHeader.Text = sb.ToString();
        //}

        private void CbbContentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0)
            {
                var selectedItem = e.AddedItems[0] as ComboBoxItem;
                if (selectedItem != null)
                {
                    //RequestHeaders["Content-Type"] = selectedItem.Content.ToString();
                }
            }
        }

        private void Header_Checked(object sender, RoutedEventArgs e)
        {
            var headerControl = sender as HeaderControl;
            if (headerControl != null && !string.IsNullOrWhiteSpace(headerControl.HeaderKey) && !string.IsNullOrWhiteSpace(headerControl.HeaderValue))
            {
                RequestHeaders.AddOrUpdate(headerControl.HeaderKey.Trim(), headerControl.HeaderValue.Trim(), StringComparer.OrdinalIgnoreCase);
            }
        }
    }
}