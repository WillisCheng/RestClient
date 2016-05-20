using System;
using System.Windows;
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel = new SenderViewModel();
        }
    }
}