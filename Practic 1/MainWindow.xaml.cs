using System.Windows;
using Practic_1.DataSet1TableAdapters;

namespace Practic_1
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
    
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page1();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new Page2();
        }
    }

}
