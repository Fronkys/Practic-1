using Practic_1.DataSet1TableAdapters;
using System.Windows;
using System.Windows.Controls;


namespace Practic_1
{
    
    public partial class Page2 : Page
    {
        BuyersTableAdapter Buyers = new BuyersTableAdapter();
        public Page2()
        {
            InitializeComponent();
            BuyersGrid.ItemsSource = Buyers.GetData();
        }
    }
}
