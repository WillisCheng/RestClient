using System;
using System.Windows;

namespace SenderTest
{
    /// <summary>
    /// Interaction logic for HeaderControl.xaml
    /// </summary>
    public partial class HeaderControl
    {
        public event Action<object, RoutedEventArgs> Checked;

        public HeaderControl()
        {
            InitializeComponent();
        }

        //public static readonly DependencyProperty IsCheckedProperty =
        //    DependencyProperty.Register("IsChecked", typeof(bool), typeof(HeaderControl), new PropertyMetadata(false, Checked));

        //private static void Checked(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        //{
        //}

        public bool IsChecked
        {
            get
            {
                return CbbChecked.IsChecked.GetValueOrDefault();//(bool)GetValue(IsCheckedProperty);
            }
            set
            {
                //SetValue(IsCheckedProperty, value);
                CbbChecked.IsChecked = value;
            }
        }

        public string HeaderKey
        {
            get
            {
                return TxtHeaderKey.Text;
            }
            set
            {
                TxtHeaderKey.Text = value;
            }
        }

        public string HeaderValue
        {
            get
            {
                return TxtHeaderValue.Text;
            }
            set
            {
                TxtHeaderValue.Text = value;
            }
        }

        private void CbbChecked_Checked(object sender, RoutedEventArgs e)
        {
            if (Checked != null)
            {
                Checked(this, e);
            }
        }
    }
}